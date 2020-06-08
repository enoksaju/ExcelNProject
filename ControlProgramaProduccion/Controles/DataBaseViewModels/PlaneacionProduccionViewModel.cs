using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlProgramaProduccion.ViewModels;
using static libProduccionDataBase.Tablas.PlaneacionProduccion;

namespace ControlProgramaProduccion.Controles.DataBaseViewModels
{
	public class PlaneacionProduccionViewModel : NotifyPropertyChangedBase, INotifyPropertyChanged
	{
		private libProduccionDataBase.Tablas.PlaneacionProduccion _Entity = null;

		public libProduccionDataBase.Tablas.PlaneacionProduccion Entity
		{
			get { return _Entity; }
			set
			{
				if ( _Entity != value )
				{
					_Entity = value;
					OnPropertyChange ( );
					OnPropertyChange ( "IsSelected" );
				}
			}
		}

		public DateTime? FechaProgramada
		{
			get { return _Entity.FechaProgramada; }
			set
			{
				if ( _Entity.FechaProgramada != value )
				{
					_Entity.FechaProgramada = value;
					OnPropertyChange ( );
				}
			}
		}

		public int? MaquinaId
		{
			get { return _Entity.MaquinaId; }
			set
			{
				if ( _Entity.MaquinaId != value )
				{
					_Entity.MaquinaId = value;
					OnPropertyChange ( );
				}
			}
		}

		public bool EsProgramada
		{
			get { return Entity.Estatus.HasFlag ( statusProcesoProduccion.Programada ); }
			set
			{
				if ( Entity.Estatus.HasFlag ( statusProcesoProduccion.Programada ) != value )
				{
					if ( value )
					{
						Entity.Estatus |= statusProcesoProduccion.Programada;
					}
					else
					{
						Entity.Estatus &= ~statusProcesoProduccion.Programada;
					}
				}
			}
		}

		public bool IsSelected
		{
			get { return _Entity.IsSelected; }
			set
			{
				if ( _Entity.IsSelected != value )
				{
					_Entity.IsSelected = value;
					OnPropertyChange ( );
				}
			}
		}

		// Abro el control de edicion para el Modelo, requiere un contexto de BD donde se encuentre alojada la entidad
		/// <summary>
		/// Abre un cuadro de dialogo para la edicion del elemento
		/// </summary>
		/// <param name="AutoSaveChanges">Indica si se guardara la informacion en la BD al momento de hacer click en el botón guardar</param>
		/// <returns></returns>
		public async Task<bool> Edit (bool AutoSaveChanges = true)
		{
			var view = new Calendario.Controles.Dialogs.EditarPlaneacionProduccionViewDialog ( ) { DataContext = this };
			var t = (bool)await MaterialDesignThemes.Wpf.DialogHost.Show ( view, "RootDialog" );

			var DBCtx = GetContextFromEntity.GetDbContextFromEntity ( this.Entity );
			if ( DBCtx != null && AutoSaveChanges == true )
			{
				if ( t )
				{					
					DBCtx.SaveChanges ( );
				}
				else
				{
					DBCtx.Entry ( this.Entity ).Reload ( );
				}
			}

			return t;
		}
	}
}
