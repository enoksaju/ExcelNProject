using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using EstacionPesaje.DockContents.ICatalogFormEnums;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Identity;
using libProduccionDataBase.Identity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using WeifenLuo.WinFormsUI.Docking;


namespace EstacionPesaje.DockContents.Catalogos
{
    public partial class CatalogoUsuarios : KryptonDockContentFormBase, ICatalogForm
    {
        private int PreviewUserIdSelected;

        public CatalogoUsuarios( DataBaseContexto DB )
        {
            InitializeComponent();

            OnStatusStringChanged( "Creando el Formulario" );

            // Asigno las paginas a sus botones de navegacion
            this.NavigatorAddkryptonButton.Tag = AddUserKP;
            this.NavigatorEditkryptonButton.Tag = EditUserKP;
            this.NavigatorPasswordkryptonButton.Tag = ChangePasswordKP;
            this.NavigatorRolkryptonButton.Tag = RoleManagerKP;
            OnStatusStringChanged( "Listo" );
        }
        private async void CatalogoUsuarios_Load( object sender, EventArgs e )
        {
            OnStatusStringChanged( "Cargando el formulario" );
            await RefreshListBox();
            using (libProduccionDataBase.Contexto.DataBaseContexto context = new DataBaseContexto())
            {
                await context.Roles.LoadAsync();
                this.applicationRoleBindingSource.DataSource = context.Roles.Local.ToList();
            }

            OnStatusStringChanged( "Listo");
        }

        #region Navegación

        /// <summary>
        /// Coloca la pagina correspondiente al boton presionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navigation_Click( object sender, EventArgs e )
        {
            kryptonNavigator1.SelectedPage = (ComponentFactory.Krypton.Navigator.KryptonPage)((KryptonButton)sender).Tag;
        }

        /// <summary>
        /// Refresca el contenido de las lista de usuarios
        /// </summary>
        /// <returns></returns>
        public async Task RefreshListBox()
        {
            usuarioBasicInfoBindingSource.DataSource = await libProduccionDataBase.Identity.Model.UsuarioBasicInfo.GetUsersBasicInfo();
            usuarioBasicInfoBindingSource.ResetBindings( false );
            kryptonListBox1.Invalidate();
        }

        /// <summary>
        /// Se desencadena cuando se ha cambiado el usuario seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void kryptonListBox1_SelectedValueChanged( object sender, EventArgs e )
        {
            try
            {
                if (PreviewUserIdSelected != (int)kryptonListBox1.SelectedValue)
                {
                    await LoadUserRoles();
                }
                PreviewUserIdSelected = (int)kryptonListBox1.SelectedValue;

            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
        }

        #endregion

        #region Add New User

        /// <summary>
        /// Ejecuta la tarea para agregar un usuario nuevo con valores de rol por defecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveNew_Click( object sender, EventArgs e )
        {
            await addUser();
            await RefreshListBox();
        }

        /// <summary>
        /// Agrega un usuario al sistema, toma los datos de los cuadros de texto en la ventana
        /// </summary>
        /// <returns></returns>
        private async Task<bool> addUser()
        {
            try
            {

                using (libProduccionDataBase.Contexto.DataBaseContexto context = new DataBaseContexto())
                {
                    using (var UsrManager = new libProduccionDataBase.Identity.ApplicationUserManager( new libProduccionDataBase.Identity.ApplicationUserStore( context ) ))
                    {
                        this.OnStatusStringChanged( "Agregando Usuario" );
                        CreatingUserModel _usr= new CreatingUserModel
                        {
                            Nombre = AddNombreKTbox.Text,
                            ApellidoPaterno = AddApPaternoKTbox.Text,
                            ApellidoMaterno = AddApMaternoKTbox.Text,
                            ClaveTrabajador = AddClaveKTbox.Text,
                            LoginName= AddLoginNameKTbox.Text.ToUpper(),
                            Email = AddEmailKTbox.Text,
                            Contraseña= AddPasswordKTbox.Text,
                            ConfirmeContraseña= AddConfirmPasswordKTbox.Text
                        };

                        ValidationContext validator = new ValidationContext(_usr);
                        List<ValidationResult> results = new List<ValidationResult>();

                        if (Validator.TryValidateObject( _usr, validator, results, true ))
                        {
                            if (context.Users.Any( g => g.UserName == _usr.LoginName ))
                            {
                                var FoundUser =await UsrManager.FindByNameAsync(_usr.LoginName);

                                throw new Exception( String.Format( "El nombre de usuario {0} ya existe.\n\n{5,15} {1} {2} {3}\n{6,19} {4}", _usr.LoginName, FoundUser.Nombre, FoundUser.ApellidoPaterno, FoundUser.ApellidoMaterno, FoundUser.ClaveTrabajador, "Nombre:", "Clave:" ) );
                            };

                            var usr= _usr.ToApplicationUser();
                            IdentityResult result = await  UsrManager.CreateAsync(usr, AddPasswordKTbox.Text);

                            if (result.Succeeded)
                            {
                                UsrManager.AddToRole( usr.Id, "Usuario General" );
                                this.OnStatusStringChanged("Usuario Agregado" );
                            }
                            else
                            {
                                StringBuilder strbld = new StringBuilder();
                                result.Errors.ToList().ForEach( err =>
                                {
                                    strbld.AppendFormat( "•{0}\n", err );
                                } );

                                throw new Exception( strbld.ToString() );
                            }
                            return result.Succeeded;
                        }
                        else
                        {
                            StringBuilder strbld = new StringBuilder();
                            results.ForEach( err =>
                            {
                                strbld.AppendFormat( "•{0}\n", err.ErrorMessage );
                            } );

                            throw new Exception( strbld.ToString() );
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                KryptonTaskDialog.Show( "Algo va mal..", "Error", libProduccionDataBase.Auxiliares.GetInnerException( ex ), MessageBoxIcon.Error, TaskDialogButtons.OK );
                this.OnStatusStringChanged( "Error al agregar al usuario!" );
                return false;
            }
        }

        #endregion
        
        #region Edit User

        /// <summary>
        /// Ejecuta la tarea de actualizacion de datos de un usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveEdit_Click( object sender, EventArgs e )
        {
            await SaveEdit();
            await RefreshListBox();
        }

        /// <summary>
        /// Actualiza los datos del usuario seleccionado
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveEdit()
        {
            try
            {

                using (libProduccionDataBase.Contexto.DataBaseContexto context = new DataBaseContexto())
                {
                    using (var UsrManager = new libProduccionDataBase.Identity.ApplicationUserManager( new libProduccionDataBase.Identity.ApplicationUserStore( context ) ))
                    {
                        var _usr= ((UsuarioBasicInfo)usuarioBasicInfoBindingSource.Current);
                        this.OnStatusStringChanged( "Actualizando Usuario" );

                        ValidationContext validator = new ValidationContext(_usr);
                        List<ValidationResult> results = new List<ValidationResult>();
                        bool IsValid = Validator.TryValidateObject( _usr, validator, results, true );


                        if (IsValid)
                        {
                            IdentityResult Result= await UsrManager.UpdateAsync(await _usr.ToUpdatedUser(UsrManager));

                            if (!Result.Succeeded)
                            {
                                StringBuilder strbld = new StringBuilder();
                                Result.Errors.ToList().ForEach( err =>
                                {
                                    strbld.AppendFormat( "•{0}\n", err );
                                } );

                                throw new Exception( strbld.ToString() );
                            }

                            this.OnStatusStringChanged( "Usuario Actualizado" );

                            return Result.Succeeded;
                            
                        }
                        else
                        {
                            StringBuilder strbld = new StringBuilder();
                            results.ForEach( err =>
                            {
                                strbld.AppendFormat( "•{0}\n", err.ErrorMessage );
                            } );

                            throw new Exception( strbld.ToString() );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonTaskDialog.Show( "Algo va mal..", "Error", libProduccionDataBase.Auxiliares.GetInnerException( ex ), MessageBoxIcon.Error, TaskDialogButtons.OK );
                this.OnStatusStringChanged( "Error al actualizar al usuario!" );
                return false;
            }
        }

        #endregion

        #region Override Voids
        public void Actualizar( object sender, EventArgs e )
        {
            throw new NotImplementedException();
        }

        public void Agregar( object sender, EventArgs e )
        {
            throw new NotImplementedException();
        }

        public void Buscar( object sender, string SearchString )
        {
            throw new NotImplementedException();
        }

        public void Editar( object sender, EventArgs e )
        {
            throw new NotImplementedException();
        }

        public void Eliminar( object sender, EventArgs e )
        {
            throw new NotImplementedException();
        }

        public void RefreshBindingSource( object sender, EventArgs e )
        {
            throw new NotImplementedException();
        }

        public void Show( DockPanel Panel, FlagActiveFunctions Functions )
        {
            this.Show( Panel );
        }

        public void showDetails( object sender, EventArgs e )
        {
            throw new NotImplementedException();
        }
        #endregion
        
        #region Roles

        /// <summary>
        /// Carga los roles con los que cuenta un usuario y los muestra en el ListBox
        /// </summary>
        /// <returns></returns>
        public async Task LoadUserRoles()
        {
            try
            {
                using (libProduccionDataBase.Contexto.DataBaseContexto context = new DataBaseContexto())
                {
                    context.Database.Log = Console.WriteLine;

                    using (var UsrManager = new libProduccionDataBase.Identity.ApplicationUserManager( new libProduccionDataBase.Identity.ApplicationUserStore( context ) ))
                    {
                        var t= await UsrManager.GetRolesAsync( (int)kryptonListBox1.SelectedValue );
                        RolesUserListBox.Items.Clear();
                        RolesUserListBox.Items.AddRange( t.ToArray() );
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #region Add Or Remove Roles

        /// <summary>
        /// Agrega un rol a un usuario siempre y cuando el usuario logeado sea un Administrador o un desarrollador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddRoleToUserBtn_Click( object sender, EventArgs e )
        {
            this.OnStatusStringChanged( "Agregando Rol..." );
            try
            {
                using (libProduccionDataBase.Contexto.DataBaseContexto context = new DataBaseContexto())
                {
                    context.Database.Log = Console.WriteLine;

                    using (var UsrManager = new libProduccionDataBase.Identity.ApplicationUserManager( new libProduccionDataBase.Identity.ApplicationUserStore( context ) ))
                    {
                        if ((UsrManager.IsInRole( Program.User.Id, "Develop" ) || UsrManager.IsInRole( Program.User.Id, "Administrador" )) && applicationRoleBindingSource.Current != null && ((ApplicationRole)applicationRoleBindingSource.Current).Name != "Develop")
                        {
                            context.Database.Log = Console.WriteLine;
                            await UsrManager.AddToRoleAsync( (int)kryptonListBox1.SelectedValue, ((ApplicationRole)applicationRoleBindingSource.Current).Name );
                            await LoadUserRoles();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
               
                this.OnStatusStringChanged( "Error al agregar el rol..." );
                throw ex;
            }
        }


        /// <summary>
        /// Quita un rol al usuario seleccionado siempre y cuando el usuario logeado se un Administrador o un desarrollador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RemoveRoleToUserBtn_Click( object sender, EventArgs e )
        {
            this.OnStatusStringChanged( "Quitando Rol..." );
            try
            {
                if (RolesUserListBox.SelectedItem != null && !(((ApplicationRole)applicationRoleBindingSource.Current).Id == 1 && ((string)RolesUserListBox.SelectedItem) == "Develop"))
                {
                    using (libProduccionDataBase.Contexto.DataBaseContexto context = new DataBaseContexto())
                    {
                        context.Database.Log = Console.WriteLine;

                        using (var UsrManager = new libProduccionDataBase.Identity.ApplicationUserManager( new libProduccionDataBase.Identity.ApplicationUserStore( context ) ))
                        {
                            await UsrManager.RemoveFromRoleAsync( (int)kryptonListBox1.SelectedValue, (string)RolesUserListBox.SelectedItem );
                            await LoadUserRoles();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.OnStatusStringChanged( "Error al quitar el rol..." );
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Password Manager


        /// <summary>
        /// Cambia el password del usuario actual, si el usuario logeado es un Administrador o un Deserrollador, no es necesario indicar el password anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CambiarPassword_Click( object sender, EventArgs e )
        {
            this.OnStatusStringChanged( "Cambiando la contraseña..." );
            IdentityResult result;
            try
            {
                if (ChangePasswordPasswordTxt.Text != ChangePasswordConfirmPasswordTxt.Text) throw new Exception( "La contraseña y su confirmacion no coinciden." );


                using (libProduccionDataBase.Contexto.DataBaseContexto context = new DataBaseContexto())
                {
                    context.Database.Log = Console.WriteLine;

                    using (var UsrManager = new libProduccionDataBase.Identity.ApplicationUserManager( new libProduccionDataBase.Identity.ApplicationUserStore( context ) ))
                    {

                        if ((UsrManager.IsInRole( Program.User.Id, "Develop" ) || UsrManager.IsInRole( Program.User.Id, "Administrador" )) && (int)kryptonListBox1.SelectedValue != 1)
                        {

                            var provider = new DpapiDataProtectionProvider("ExcelNoblezaControlProduccion");
                            UsrManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, int>( provider.Create( "ASP.NET Identity" ) );

                            var t= await UsrManager.GeneratePasswordResetTokenAsync( (int )kryptonListBox1.SelectedValue );
                            result = await UsrManager.ResetPasswordAsync( (int)kryptonListBox1.SelectedValue, t, ChangePasswordPasswordTxt.Text );

                        }
                        else
                        {
                            result = await UsrManager.ChangePasswordAsync( (int)kryptonListBox1.SelectedValue, ChangePasswordCurrentPasswordTxt.Text, ChangePasswordPasswordTxt.Text );
                        }

                        if (!result.Succeeded)
                        {
                            StringBuilder strbld = new StringBuilder();
                            result.Errors.ToList().ForEach( err =>
                            {
                                strbld.AppendFormat( "•{0}\n", err );
                            } );

                            throw new Exception( strbld.ToString() );
                        }


                        this.OnStatusStringChanged( "Contraseña Actualizada..." );
                        await LoadUserRoles();
                        KryptonTaskDialog.Show( "Muy bien...", "Correcto", "Se ha cambiado la contraseña al usuario seleccionado", MessageBoxIcon.Information, TaskDialogButtons.OK );
                    }
                }


            }
            catch (Exception ex)
            {
                KryptonTaskDialog.Show( "Algo va mal...", "Error", ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK );
                this.OnStatusStringChanged( "Error al cambiar la contraseña!" );
            }

        }
        #endregion
    }
}
