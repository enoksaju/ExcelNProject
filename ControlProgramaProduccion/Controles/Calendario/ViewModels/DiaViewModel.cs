using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ControlProgramaProduccion.Controles.Calendario.ViewModels;
using ControlProgramaProduccion.Controles.DataBaseViewModels;
using ControlProgramaProduccion.ViewModels;
using GongSolutions.Wpf.DragDrop;
using libProduccionDataBase.Tablas;
using static libProduccionDataBase.Tablas.PlaneacionProduccion;

namespace ControlProgramaProduccion.Controles.Calendario.ViewModels
{
	public class DiaViewModel : NotifyPropertyChangedBase, INotifyPropertyChanged, IDropTarget
	{
		private DateTime? _Dia;
		private List<PlaneacionProduccionViewModel> _ParentItemsContainer = new List<PlaneacionProduccionViewModel> ( );
		public Calendario.ViewModels.CalendarViewModel ParentCalendar { get; set; }

		#region Eventos
		// Evento que indica que el Drop se completó
		public event EventHandler<DropCompletedEventArg> DropCompleted;
		public event EventHandler<DropCompletedEventArg> DragInitialized;
		#endregion
		// Asigno la fecha del control
		public DateTime? Dia
		{
			get
			{
				return _Dia;
			}
			set
			{
				if ( _Dia != value )
				{
					_Dia = value;
					OnPropertyChange ( "Header" );
					OnPropertyChange ( );
				}
			}
		}
		// Asigno la cabecera del control
		public string Header { get { return _Dia == null ? "Sin Asignar" : _Dia?.ToString ( "ddd, dd MMM" ); } }
		public List<PlaneacionProduccionViewModel> ParentItemsContainer
		{
			get { return _ParentItemsContainer; }
			set
			{
				_ParentItemsContainer = value;
				OnPropertyChange ( );
				OnPropertyChange ( "TodayItems" );
			}
		}
		// Muestra los elementos que se programaron en el dia
		public List<PlaneacionProduccionViewModel> TodayItems
		{
			get
			{

				if ( Dia != null )
				{

					return _ParentItemsContainer.Where ( u => u.Entity.FechaProgramada?.Date == Dia?.Date && u.Entity.MaquinaId == ParentCalendar.MaquinaId ).OrderBy ( o => o.Entity.prioridad ).ToList ( );
				}
				else
				{
					return _ParentItemsContainer.OrderBy ( o => o.Entity.prioridad ).ToList ( );
				}
			}
		}

		// Muestra el total de metros en el dia
		public int TotalMetros
		{
			get { return TodayItems.Sum ( o => o.Entity.Planeacion.OrdenTrabajo.TempCapt.ML ); }
		}

		// Muestra el numeor de cambios en el dia
		public int NumCambios
		{
			get { return TodayItems.Count; }
		}

		// Actualizo las vistas
		public void Refresh ()
		{
			OnPropertyChange ( "Dia" );
			OnPropertyChange ( "TodayItems" );
			OnPropertyChange ( "TotalMetros" );
			OnPropertyChange ( "NumCambios" );
		}

		//Constructor
		public DiaViewModel ( CalendarViewModel Cal )
		{
			// Asigno el parent al control
			ParentCalendar = Cal;
		}

		// Asigno el item como seleccionado
		public void SetIsSelected ( PlaneacionProduccionViewModel Item )
		{
			try
			{
				Item.IsSelected = true;
				foreach ( var itm in ParentItemsContainer.Where ( i => i != Item ) )
				{
					itm.IsSelected = false;
				}
			}
			catch ( Exception ex )
			{

				throw;
			}
		}

		/// <summary>
		/// Muestra un Dialogo para poder editar un elemento seleccioado
		/// </summary>
		/// <param name="plan"></param>
		public async void ShowEdit ( PlaneacionProduccionViewModel plan )
		{
			if ( await plan.Edit ( ) )
			{
				if ( !plan.EsProgramada && !ParentCalendar.UnasignedItems.ParentItemsContainer.Any ( o => o.Entity.OT == plan.Entity.OT ) )
				{
					ParentCalendar.UnasignedItems.ParentItemsContainer.Add ( plan );
					ParentCalendar.AsignedItems.Remove ( plan );
				}
			}
			ParentCalendar.SetIsSelected ( plan );
			ParentCalendar.RefreshLists ( );
		}

		#region DragDrop
		private bool _IsDropTarget = true;
		/// <summary>
		/// Determinara si el elemento puede o no recibir drops
		/// </summary>
		public bool IsDropTarget
		{
			get { return _IsDropTarget; }
			set
			{
				if ( _IsDropTarget != value )
				{
					_IsDropTarget = value;
					OnPropertyChange ( );
				}
			}
		}

		void IDropTarget.DragOver ( IDropInfo dropInfo )
		{
			DragDrop.DefaultDropHandler.DragOver ( dropInfo );

			var item = ( (PlaneacionProduccionViewModel)dropInfo.Data );
			var fromUnasigned = !( (DiaViewModel)( (Control)dropInfo.DragInfo.VisualSource ).Tag ).IsDropTarget;

			DragInitialized?.Invoke ( this, new DropCompletedEventArg ( item, fromUnasigned ) );
		}

		void IDropTarget.Drop ( IDropInfo dropInfo )
		{
			// Default Drop Void
			DragDrop.DefaultDropHandler.Drop ( dropInfo );

			// Reviso si el origen es desde los elementos sin asignar
			var fromUnasigned = !( (DiaViewModel)( (Control)dropInfo.DragInfo.VisualSource ).Tag ).IsDropTarget;
			var ToUnasigned = !( (DiaViewModel)( (Control)dropInfo.VisualTarget ).Tag ).IsDropTarget;

			// Obtengo el Item que se esta moviendo
			var item = ( (PlaneacionProduccionViewModel)dropInfo.Data );

			if ( ToUnasigned )
			{
				// Cambio el estatus del elemento a Programada
				item.Entity.Estatus &= ~statusProcesoProduccion.Programada;
				// Asigno la maquina al Item
				item.Entity.MaquinaId = null;
				item.Entity.prioridad = 0;
			}
			else
			{
				// ListBox al que se envia el elemento
				var lsb = ( (ListBox)dropInfo.VisualTarget );
				// Asigno la prioridad de acuerdo al indice de ubicacion en el ListBox
				item.Entity.prioridad = dropInfo.InsertIndex;

				// Modifico la prioridad de los demas elementos
				for ( int i = 0; i < lsb.Items.Count; i++ )
				{
					if ( ( (PlaneacionProduccionViewModel)lsb.Items[ i ] ) != item )
					{

						if ( i >= dropInfo.InsertIndex )
						{
							( (PlaneacionProduccionViewModel)lsb.Items[ i ] ).Entity.prioridad = i + 1;
						}
						else
						{
							( (PlaneacionProduccionViewModel)lsb.Items[ i ] ).Entity.prioridad = i;
						}
					}

				}

				// Asigno valores al item que se mueve
				item.FechaProgramada = Dia;
				// Cambio el estatus del elemento a Programada
				item.Entity.Estatus |= statusProcesoProduccion.Programada;
				// Asigno la maquina al Item
				item.Entity.MaquinaId = ParentCalendar.MaquinaId;
				// Le asignno el valor como elemento seleccionado
				SetIsSelected ( item );
			}
			
			// Disparo el evento de DropCompleted
			DropCompleted?.Invoke ( this, new DropCompletedEventArg ( item, fromUnasigned ) );
		}
		#endregion
	}
}
