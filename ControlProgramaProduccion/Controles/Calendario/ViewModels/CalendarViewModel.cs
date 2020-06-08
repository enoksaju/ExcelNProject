using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ControlProgramaProduccion.Controles.DataBaseViewModels;
using ControlProgramaProduccion.ViewModels;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;
using static libProduccionDataBase.Tablas.PlaneacionProduccion;

namespace ControlProgramaProduccion.Controles.Calendario.ViewModels
{
	public class CalendarViewModel : NotifyPropertyChangedBase, INotifyPropertyChanged
	{
		private int? _MaquinaId;
		private libProduccionDataBase.Tablas.Planeacion.TiposProcesoProduccion _Proceso;
		private DateTime _DiaInicial;
		private List<PlaneacionProduccionViewModel> _AsignedItems = new List<PlaneacionProduccionViewModel> ( );

		public DataBaseContexto DBContext { get; set; }
		public DateTime DiaInicial
		{
			get
			{
				return _DiaInicial;
			}
			set
			{
				if ( value.Date != _DiaInicial.Date )
				{
					_DiaInicial = value.Date;
					OnPropertyChange ( );
					OnPropertyChange ( "Semana" );

					Dia1.Dia = _DiaInicial.AddDays ( 0 );
					Dia2.Dia = _DiaInicial.AddDays ( 1 );
					Dia3.Dia = _DiaInicial.AddDays ( 2 );
					Dia4.Dia = _DiaInicial.AddDays ( 3 );
					Dia5.Dia = _DiaInicial.AddDays ( 4 );
					Dia6.Dia = _DiaInicial.AddDays ( 5 );
					Dia7.Dia = _DiaInicial.AddDays ( 6 );
					Task.Run ( () =>
					{
						LoadItems ( true );
					} );
					// refreshLists ( ); // TODO: Make Void()
				}
			}
		}
		public int Semana { get { return System.Globalization.CultureInfo.InvariantCulture.Calendar.GetWeekOfYear ( _DiaInicial, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday ); } }
		public int? MaquinaId
		{
			get
			{
				return _MaquinaId;
			}
			set
			{
				if ( _MaquinaId != value )
				{
					_MaquinaId = value;
					OnPropertyChange ( );
					Task.Run ( () =>
					{
						LoadItems ( true );
					} );
				}
			}
		}

		public List<Maquina> Maquinas
		{
			get
			{
				var Maq = DBContext.Maquinas.ToList ( );

				return Maq.Where ( o => o.Procesos.HasFlag ( Proceso ) ).ToList ( );
			}
		}

		public List<PlaneacionProduccionViewModel> AsignedItems
		{
			get
			{
				return _AsignedItems;
			}
			set
			{
				if ( _AsignedItems != value )
				{
					_AsignedItems = value;
					OnPropertyChange ( );
					Dia1.ParentItemsContainer = AsignedItems;
					Dia2.ParentItemsContainer = AsignedItems;
					Dia3.ParentItemsContainer = AsignedItems;
					Dia4.ParentItemsContainer = AsignedItems;
					Dia5.ParentItemsContainer = AsignedItems;
					Dia6.ParentItemsContainer = AsignedItems;
					Dia7.ParentItemsContainer = AsignedItems;
					OnPropertyChange ( "Dia1" );
					OnPropertyChange ( "Dia2" );
					OnPropertyChange ( "Dia3" );
					OnPropertyChange ( "Dia4" );
					OnPropertyChange ( "Dia5" );
					OnPropertyChange ( "Dia6" );
					OnPropertyChange ( "Dia7" );
				}
			}
		}

		public DiaViewModel Dia1 { get; set; }
		public DiaViewModel Dia2 { get; set; }
		public DiaViewModel Dia3 { get; set; }
		public DiaViewModel Dia4 { get; set; }
		public DiaViewModel Dia5 { get; set; }
		public DiaViewModel Dia6 { get; set; }
		public DiaViewModel Dia7 { get; set; }
		public DiaViewModel UnasignedItems { get; set; }

		public Planeacion.TiposProcesoProduccion Proceso
		{
			get
			{
				return _Proceso;
			}
			set
			{
				_Proceso = value;
				OnPropertyChange ( );
				OnPropertyChange ( "Maquinas" );

				if ( !Maquinas.Any ( o => o.Id == MaquinaId ) ) MaquinaId = null;

				Task.Run ( () =>
				{
					LoadItems ( true );
				} );
			}
		}
		public CalendarViewModel ()
		{
			this.DBContext = new DataBaseContexto ( );
			this.DBContext.Database.Log = null;

			Dia1 = new DiaViewModel ( this );
			Dia2 = new DiaViewModel ( this );
			Dia3 = new DiaViewModel ( this );
			Dia4 = new DiaViewModel ( this );
			Dia5 = new DiaViewModel ( this );
			Dia6 = new DiaViewModel ( this );
			Dia7 = new DiaViewModel ( this );
			UnasignedItems = new DiaViewModel ( this ) { IsDropTarget = false };
			DiaInicial = GetLunes ( DateTime.Now );
			Task.Run ( () =>
			{
				LoadItems ( true );
			} );

			Dia1.DropCompleted += Dia_DropCompleted;
			Dia2.DropCompleted += Dia_DropCompleted;
			Dia3.DropCompleted += Dia_DropCompleted;
			Dia4.DropCompleted += Dia_DropCompleted;
			Dia5.DropCompleted += Dia_DropCompleted;
			Dia6.DropCompleted += Dia_DropCompleted;
			Dia7.DropCompleted += Dia_DropCompleted;
			UnasignedItems.DropCompleted += UnasignedItems_DropCompleted;
		}

		private void UnasignedItems_DropCompleted ( object sender, DropCompletedEventArg e )
		{
			if ( AsignedItems.Any ( O => O.Entity.OT == e.Item.Entity.OT ) )
			{
				AsignedItems.Remove ( AsignedItems.FirstOrDefault ( O => O.Entity.OT == e.Item.Entity.OT && O.Entity.TipoProceso == e.Item.Entity.TipoProceso ) );
				UnasignedItems.ParentItemsContainer.Add ( e.Item );
				if ( DBContext != null )
				{
					Task.Run ( () => { DBContext.SaveChanges ( ); ; } );
				}
				RefreshLists ( );
			}
		}

		private void Dia_DropCompleted ( object sender, DropCompletedEventArg e )
		{
			if ( MaquinaId == null ) throw new Exception ( "No se seleccionó la maquina destino!, \nno puede arrastar la orden al calendario, por favor seleccione una maquina" );

			if ( e.fromUnasigned )
			{
				if ( UnasignedItems.ParentItemsContainer.Any ( O => O.Entity.OT == e.Item.Entity.OT && O.Entity.TipoProceso == e.Item.Entity.TipoProceso ) )
				{
					UnasignedItems.ParentItemsContainer.Remove ( UnasignedItems.ParentItemsContainer.FirstOrDefault ( O => O.Entity.OT == e.Item.Entity.OT && O.Entity.TipoProceso == e.Item.Entity.TipoProceso ) );
				}

				AsignedItems.Add ( e.Item );
			}

			if ( !AsignedItems.Any ( o => o.Entity.OT == e.Item.Entity.OT ) )
			{
				AsignedItems.Add ( e.Item );
			}

			if ( DBContext != null )
			{
				Task.Run ( () => { DBContext.SaveChanges ( ); ; } );
			}

			RefreshLists ( );


		}
		public async void LoadItems ( bool RefreshProceso = false )
		{
			try
			{
				if ( DBContext != null )
				{
					var EndDay = DiaInicial.AddDays ( 8 );

					UnasignedItems.ParentItemsContainer = await DBContext.PlaneacionProduccion.Where ( u => u.TipoProceso.HasFlag ( Proceso ) && u.Estatus.HasFlag ( statusProcesoProduccion.PorProgramar ) && u.Activa == true && !u.Estatus.HasFlag ( statusProcesoProduccion.Programada ) ).Select ( o => new PlaneacionProduccionViewModel ( ) { Entity = o } ).ToListAsync ( );

					AsignedItems = await DBContext.PlaneacionProduccion.Where ( u => u.FechaProgramada.Value >= DiaInicial && u.FechaProgramada <= EndDay && u.Estatus.HasFlag ( statusProcesoProduccion.Programada ) && u.MaquinaId == MaquinaId ).OrderBy ( u => u.prioridad ).Select ( o => new PlaneacionProduccionViewModel ( ) { Entity = o } ).ToListAsync ( );
					RefreshLists ( );
				}
			}
			catch ( Exception ex )
			{
				System.Diagnostics.Debug.WriteLine ( ex.Message );
			}
		}


		public void RefreshLists ()
		{
			Task.Run ( () => { UnasignedItems.Refresh ( ); } );
			Task.Run ( () => { Dia1.Refresh ( ); } );
			Task.Run ( () => { Dia2.Refresh ( ); } );
			Task.Run ( () => { Dia3.Refresh ( ); } );
			Task.Run ( () => { Dia4.Refresh ( ); } );
			Task.Run ( () => { Dia5.Refresh ( ); } );
			Task.Run ( () => { Dia6.Refresh ( ); } );
			Task.Run ( () => { Dia7.Refresh ( ); } );
		}
		public void SetIsSelected ( PlaneacionProduccionViewModel Item )
		{
			Item.IsSelected = true;
			Task.Run ( () =>
			{
				foreach ( var itm in AsignedItems.Where ( i => i != Item ) )
				{
					itm.IsSelected = false;
				}
			} );

		}
		private DateTime GetLunes ( DateTime Dia )
		{
			var DiaW = Dia.DayOfWeek;
			switch ( DiaW )
			{
				case DayOfWeek.Sunday:
					return Dia.AddDays ( -7 ).Date;
				default:
					return Dia.AddDays ( -( (int)DiaW - 1 ) ).Date;
			}
		}
		#region Commads
		private ICommand _MoveNextWeekCommand;
		private ICommand _MovePreviusWeekCommand;
		private ICommand _MoveThisWeekCommand;
		private ICommand _ShowItemProgressCommand;

		// Commands
		public ICommand MoveNextWeekCommand
		{
			get
			{
				return _MoveNextWeekCommand ?? ( _MoveNextWeekCommand = new CommandHandler ( () => MoveNextWeek ( ), () => true ) );
			}
		}

		public ICommand MovePreviusWeekCommand
		{
			get
			{
				return _MovePreviusWeekCommand ?? ( _MovePreviusWeekCommand = new CommandHandler ( () => MovePreviusWeek ( ), () => true ) );
			}
		}

		public ICommand MoveThisWeekCommand
		{
			get
			{
				return _MoveThisWeekCommand ?? ( _MoveThisWeekCommand = new CommandHandler ( () => MoveThisWeek ( ), () => true ) );
			}
		}

		public ICommand ShowItemProgressCommand
		{
			get
			{
				return _ShowItemProgressCommand ?? ( _ShowItemProgressCommand = new CommandHandler ( param => ShowItemProgress ( param ), () => true ) );
			}
		}

		//Voids for Commands
		public void MovePreviusWeek ()
		{
			this.DiaInicial = GetLunes ( DiaInicial.AddDays ( -7 ) );
		}
		public void MoveNextWeek ()
		{
			this.DiaInicial = GetLunes ( DiaInicial.AddDays ( 7 ) );
		}
		public void MoveThisWeek ()
		{
			this.DiaInicial = GetLunes ( DateTime.Now );
		}
		public void ShowItemProgress ( object Item )
		{
			PlaneacionProduccionViewModel _I = (PlaneacionProduccionViewModel)Item;

			System.Diagnostics.Debug.WriteLine ( $"{ _I.Entity.Planeacion.OrdenTrabajo.PRODUCTO }: {_I.Entity.Maquina?.NombreMaquina}" );
		}

		#endregion
	}
}
