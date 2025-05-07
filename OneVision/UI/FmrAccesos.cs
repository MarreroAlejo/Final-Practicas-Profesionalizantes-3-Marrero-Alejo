using SERVICES.Domain.Composite;
using SERVICES.Domain.Exceptions.AccesoExceptions;
using SERVICES.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SERVICES.Domain.Exceptions.PatenteExceptions;
using SERVICES.Logic.Exceptions.PatenteExceptions;
using SERVICES.Logic.Exceptions.FamiliaExceptions;
using SERVICES.Facade.Extentions;
using SERVICES.Observer;

namespace UI
{
    public partial class FmrAccesos : Form, IObserver
    {
        private FamiliaLogic familiaLogic;
        private PatenteLogic patenteLogic;
        private List<Familia> todasLasFamilias;
        private List<Familia> familiasSeleccionadas;
        private List<Patente> todasLasPatentes;
        private Usuario usuarioActual; // Variable para almacenar el usuario actual

        public FmrAccesos(Usuario usuario)
        {
            familiaLogic = FamiliaLogic.GetInstance();
            patenteLogic = PatenteLogic.GetInstance();
            InitializeComponent();
            this.usuarioActual = usuario;
            LanguageNotifier.Instance.RegisterObserver(this);
            Update();
        }
        private void FmrAccesos_Load(object sender, EventArgs e)
        {
            LimpiarListBox();
            CargarTodosLosAccesos();
            VerificarConexion();
        }

        private bool VerificarConexion()
        {
            ConnectionManager.Instance.UpdateConnectionStatus();
            if (!ConnectionManager.Instance.IsConnected)
            {
                MessageBox.Show("La conexión a la base de datos se perdió. " +
                                "Por favor, verifica la configuración.",
                                "Error de Conexión",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
            return true;
        }

        private void LimpiarListBox()
        {
            LimpiarListBoxAccesosAElegir();
            LimpiarListBoxAccesosElegidos();
        }
        private void LimpiarListBoxAccesosAElegir()
        {
            listFamiliasAElegirRol.Items.Clear();
            listPatentesAElegir.Items.Clear();
        }
        private void LimpiarListBoxAccesosElegidos()
        {
            listFamiliasElegidasRol.Items.Clear();
            listPatentesElegidas.Items.Clear();
        }

        public new void Update()
        {
            TraducirTextoControles();
        }

        private void TraducirTextoControles()
        {
            lblNombreNuevoRol.Text = StringExtention.Translate("Nombre del Nuevo Rol");
            lblRolSeleccionado.Text = StringExtention.Translate("Rol seleccionado");

            btnConfirmarNuevoRol.Text = StringExtention.Translate("Confirmar");
            btnEliminar.Text = StringExtention.Translate("Eliminar");
            btnLimpiar.Text = StringExtention.Translate("Limpiar");

        }


        private void CargarTodosLosAccesos()
        {
            try
            {
                // Limpiar las listas de accesos elegidos y a elegir
                LimpiarListBoxAccesosElegidos();
                LimpiarListBoxAccesosAElegir();

                // Además, limpiar el control que muestra las familias (si se usa en la UI)
                listFamilias.Items.Clear();

                todasLasFamilias = familiaLogic.GetAllFamilias();
                if (todasLasFamilias == null || !todasLasFamilias.Any())
                    throw new FamiliaNoEncontradaException("No se encontraron familias registradas en el sistema.");

                foreach (var familia in todasLasFamilias)
                {
                    listFamiliasAElegirRol.Items.Add(familia);
                    listFamilias.Items.Add(familia);
                }

                // Cargar todas las patentes
                todasLasPatentes = patenteLogic.GetAllPatentes();
                if (todasLasPatentes == null || !todasLasPatentes.Any())
                    throw new PatenteNoEncontradoExceptions("No se encontraron patentes registradas en el sistema.");

                foreach (var patente in todasLasPatentes)
                {
                    listPatentesAElegir.Items.Add(patente);
                }
            }
            catch (FamiliaNoEncontradaException ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar familias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PatenteNoEncontradoExceptions ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar patentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listFamilias.SelectedItem != null)
            {
                Familia familiaSeleccionada = (Familia)listFamilias.SelectedItem;
                txtRolSeleccionado.Text = familiaSeleccionada.Nombre;
                LimpiarListBoxAccesosElegidos();

                // Obtener las familias y patentes que componen a la familia seleccionada
                familiaLogic.GetCountFamiliaFamilia(familiaSeleccionada);
                familiaLogic.GetCountFamiliaPatente(familiaSeleccionada);

                // Limpiar las listas de familias y patentes elegidas
                listFamiliasElegidasRol.Items.Clear();
                listFamiliasAElegirRol.Items.Clear();
                listPatentesElegidas.Items.Clear();  // Limpiar las patentes elegidas
                listPatentesAElegir.Items.Clear();   // Limpiar las patentes a elegir

                // Cargar todas las patentes en listas de elegidas o a elegir según si están relacionadas
                List<Patente> todasLasPatentes = patenteLogic.GetAllPatentes();
                // Recorrer todas las patentes disponibles
                foreach (var patente in todasLasPatentes)
                {
                    // Verificar si la patente está asociada a la familia seleccionada
                    if (familiaSeleccionada.Accesos.OfType<Patente>().Any(p => p.Id == patente.Id))
                    {
                        // Si la patente está relacionada con la familia, agregarla a las patentes elegidas
                        AgregarElementoALista(patente, listPatentesElegidas, listPatentesAElegir);
                    }
                    else
                    {
                        // Si la patente NO está relacionada con la familia, agregarla a las patentes a elegir
                        AgregarElementoALista(patente, listPatentesAElegir, listPatentesElegidas);
                    }
                }

                // Recorrer los accesos de la familia seleccionada para agregar subfamilias
                foreach (var acceso in familiaSeleccionada.Accesos)
                {
                    if (acceso is Familia subFamilia)
                    {
                        // Agregar subFamilia a la lista de familias elegidas
                        AgregarElementoALista(subFamilia, listFamiliasElegidasRol, listFamiliasAElegirRol);
                    }
                }

                // Cargar las familias no relacionadas en la lista a elegir
                foreach (Familia familia in todasLasFamilias)
                {
                    if (familia.Id != familiaSeleccionada.Id &&
                        !listFamiliasElegidasRol.Items.Cast<Familia>().Any(f => f.Id == familia.Id))
                    {
                        listFamiliasAElegirRol.Items.Add(familia);
                    }
                }
            }
        }




        private void AgregarElementoALista<T>(T elemento, ListBox listaElegidas, ListBox listaAElegir)
        {
            // Agregar el elemento solo si no está presente en la lista de elegidos
            if (!listaElegidas.Items.Cast<T>().Any(item => item.Equals(elemento)))
            {
                listaElegidas.Items.Add(elemento);
            }

            // Si el elemento está en la lista de "a elegir", lo eliminamos de allí
            var itemAElegir = listaAElegir.Items.Cast<T>().FirstOrDefault(item => item.Equals(elemento));
            if (itemAElegir != null)
            {
                listaAElegir.Items.Remove(itemAElegir);
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNuevoRol.Text = "";
            txtRolSeleccionado.Text = "";
            listFamilias.Items.Clear();
            LimpiarListBox();
            CargarTodosLosAccesos();
        }

        #region Creacion de nuevo Rol
        private void btnConfirmarNuevoRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                if (string.IsNullOrWhiteSpace(txtNuevoRol.Text))
                    throw new AccesoNoValidoException("El nombre del rol no puede estar vacío.");

                Familia familia = new Familia
                {
                    Id = Guid.NewGuid(),
                    Nombre = txtNuevoRol.Text
                };

                // Registrar la nueva familia
                familiaLogic.Registrar(familia);

                // Añadir las patentes necesarias
                AñadirPatenteNecesaria(familia);

                // Refrescar la interfaz
                LimpiarListBox();
                CargarTodosLosAccesos();
                txtNuevoRol.Text = "";
            }
            catch (AccesoNoValidoException ex)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al registrar el nuevo rol: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AñadirPatenteNecesaria(Familia familia)
        {
            try
            {
                // Crear las patentes necesarias si no existen
                Patente patenteUsuario = PatenteLogic.Instance.GetPatenteByNombre("Usuario")
                                         ?? new Patente { Nombre = "Usuario" };
                Patente patenteGestionarUsuario = PatenteLogic.Instance.GetPatenteByNombre("Gestionar Usuario")
                                                  ?? new Patente { Nombre = "Gestionar Usuario" };

                // Verificar si la familia ya tiene la patente "Usuario"
                if (!familia.Accesos.OfType<Patente>().Any(p => p.Id == patenteUsuario.Id))
                {
                    familiaLogic.Add(familia, patenteUsuario);
                }

                // Verificar si la familia ya tiene la patente "Gestionar Usuario"
                if (!familia.Accesos.OfType<Patente>().Any(p => p.Id == patenteGestionarUsuario.Id))
                {
                    familiaLogic.Add(familia, patenteGestionarUsuario);
                }

                MessageBox.Show($"Se añadieron las patentes 'Usuario' y 'Gestionar Usuario' a la familia {familia.Nombre}.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al añadir las patentes necesarias: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Añadir y Quitar permisos
        private void btnAddFamiliaPatente_Click(object sender, EventArgs e)
        {
            if (!VerificarConexion())
                return;
            Familia familiaPadre = null;
            Patente patenteHija = null;

            // Usar el método para cargar las familias
            SeleccionarFamiliayPatente(ref familiaPadre, ref patenteHija);

            // Si alguna de las familias no se asignó, terminamos la ejecución
            if (familiaPadre == null || patenteHija == null) return;

            // Agregar la familia hija a la familia padre
            familiaLogic.Add(familiaPadre, patenteHija);

            // Actualizar el conteo de relaciones para la familia padre
            familiaLogic.GetCountFamiliaFamilia(familiaPadre);

            if (!listPatentesElegidas.Items.Cast<Patente>().Any(p => p.Nombre == patenteHija.Nombre))
            {
                listPatentesElegidas.Items.Add(patenteHija);
            }
            listPatentesAElegir.Items.Remove(patenteHija);

            // Confirmación de la operación
            MessageBox.Show($"Se asignó al Rol {familiaPadre.Nombre} el Rol {patenteHija.Nombre}");
        }

        public void SeleccionarFamiliayPatente(ref Familia familiaPadre, ref Patente patenteHija)
        {
            // Verificar si ya se ha asignado familiaPadre y patenteHija
            if (familiaPadre != null && patenteHija != null)
            {
                return;  // Salir si ya se ha asignado todo correctamente
            }

            // Proceder con la asignación si no se había hecho
            if (listFamilias.SelectedItem != null && listPatentesAElegir.SelectedItem != null)
            {
                familiaPadre = listFamilias.SelectedItem as Familia;
                patenteHija = listPatentesAElegir.SelectedItem as Patente;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtRolSeleccionado.Text))
                {
                    familiaPadre = new Familia { Nombre = txtRolSeleccionado.Text };
                }
                else
                {
                    MessageBox.Show("Debe seleccionar o ingresar el nombre de la familia padre.");
                    return;
                }
            }

            // Validar que ambas familias sean seleccionadas
            if (familiaPadre == null || patenteHija == null)
            {
                MessageBox.Show("Debe seleccionar ambas familias.");
                return;
            }
        }

        private void btnAddFamiliaFamilia_Click(object sender, EventArgs e)
        {
            if (!VerificarConexion())
                return;
            Familia familiaPadre = null;
            Familia familiaHija = null;

            // Cargar las familias (por ejemplo, seleccionadas en la UI)
            CargarFamiliasdeFamilia(ref familiaPadre, ref familiaHija);

            // Si alguna de las familias no se asignó, terminar la ejecución
            if (familiaPadre == null || familiaHija == null)
                return;

            // 1. Agregar la familia hija como acceso del padre
            familiaLogic.Add(familiaPadre, familiaHija);
            familiaLogic.GetCountFamiliaFamilia(familiaPadre);

            // 2. Agregar las patentes de la familia hija a la familia padre (si aún no están asociadas)
            foreach (var patente in familiaHija.Accesos.OfType<Patente>())
            {
                if (!familiaPadre.Accesos.OfType<Patente>().Any(p => p.Id == patente.Id))
                {
                    // Asocia la patente en BD (sp_InsertFamilia_Patente) y en la estructura de la familia
                    familiaLogic.Add(familiaPadre, patente);
                }
            }

            // 3. Actualizar la UI para las familias:
            //   - En la lista de familias asignadas, agregar la familia hija.
            //   - En la lista de familias disponibles, remover la familia hija.
            if (listFamiliasAElegirRol.Items.Contains(familiaHija))
            {
                listFamiliasAElegirRol.Items.Remove(familiaHija);
            }
            if (!listFamiliasElegidasRol.Items.Contains(familiaHija))
            {
                listFamiliasElegidasRol.Items.Add(familiaHija);
            }

            // 4. Actualizar la UI para las patentes:
            //   Recorrer las patentes de la familia hija y para cada una:
            //     - Si no está en listPatentesElegidas, agregarla.
            //     - Removerla de listPatentesAElegir (si se encuentra allí).
            foreach (var patente in familiaHija.Accesos.OfType<Patente>())
            {
                if (!listPatentesElegidas.Items.Cast<Patente>().Any(p => p.Id == patente.Id))
                {
                    listPatentesElegidas.Items.Add(patente);
                }
                // Remover de la lista de patentes disponibles, si existe
                var disponible = listPatentesAElegir.Items.Cast<Patente>().FirstOrDefault(p => p.Id == patente.Id);
                if (disponible != null)
                {
                    listPatentesAElegir.Items.Remove(disponible);
                }
            }

            MessageBox.Show($"Se asignó al Rol {familiaPadre.Nombre} el Rol {familiaHija.Nombre}");
        }


        public void CargarFamiliasdeFamilia(ref Familia familiaPadre, ref Familia familiaHija)
        {
            // Asignar familiaPadre desde la lista seleccionada o desde el TextBox
            if (listFamilias.SelectedItem != null && listFamiliasAElegirRol.SelectedItem != null)
            {
                familiaPadre = listFamilias.SelectedItem as Familia;
                familiaHija = listFamiliasAElegirRol.SelectedItem as Familia;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtRolSeleccionado.Text))
                {
                    familiaPadre = new Familia { Nombre = txtRolSeleccionado.Text };
                }
                else
                {
                    MessageBox.Show("Debe seleccionar o ingresar el nombre de la familia padre.");
                    return;
                }
            }
            // Obtener todas las familias
            todasLasFamilias = familiaLogic.GetAllFamilias();

            // Validar que ambas familias sean seleccionadas
            if (familiaPadre == null || familiaHija == null)
            {
                MessageBox.Show("Debe seleccionar ambas familias.");
                return;
            }
        }
        private void btnRemoveFamiliaFamilia_Click(object sender, EventArgs e)
        {
            if (!VerificarConexion())
                return;
            Familia familiaPadre = null;
            Familia familiaHija = null;

            // Cargar las familias (padre e hija) según selección en la UI.
            CargarFamiliasdeFamiliaParaEliminar(ref familiaPadre, ref familiaHija);
            if (familiaPadre == null || familiaHija == null)
                return;

            // 1. Eliminar la relación entre familia padre y familia hija.
            familiaLogic.Delete(familiaPadre, familiaHija);

            // Actualizar la UI:
            // Remover la familia hija de la lista de familias elegidas...
            listFamiliasElegidasRol.Items.Remove(familiaHija);
            // ...y agregarla nuevamente a la lista de familias disponibles, si no se encuentra ya.
            if (!listFamiliasAElegirRol.Items.Contains(familiaHija))
            {
                listFamiliasAElegirRol.Items.Add(familiaHija);
            }

            // 2. Eliminar los accesos que la familia hija aporta a la familia padre.
            foreach (var acceso in familiaHija.Accesos.ToList())
            {
                if (acceso is Familia familiaAcceso)
                {
                    // Eliminar la relación entre la familia hija y la subfamilia asociada.
                    familiaLogic.Delete(familiaHija, familiaAcceso);
                    // Actualizar la UI: remover de las familias elegidas y agregar a las disponibles.
                    listFamiliasElegidasRol.Items.Remove(familiaAcceso);
                    if (!listFamiliasAElegirRol.Items.Contains(familiaAcceso))
                    {
                        listFamiliasAElegirRol.Items.Add(familiaAcceso);
                    }
                }
                else if (acceso is Patente patenteAcceso)
                {
                    // Solo eliminar la relación si la patente no es "necesaria"
                    if (patenteAcceso.Nombre != "Usuario" && patenteAcceso.Nombre != "Gestionar Usuario")
                    {
                        // Se elimina la relación de la patente en el contexto de la familia padre.
                        familiaLogic.Delete(familiaPadre, patenteAcceso);

                        // Actualizar la UI:
                        // Quitar la patente de la lista de patentes elegidas.
                        listPatentesElegidas.Items.Remove(patenteAcceso);
                        // Agregar la patente a la lista de patentes disponibles, si aún no está allí.
                        if (!listPatentesAElegir.Items.Cast<Patente>().Any(p => p.Id == patenteAcceso.Id))
                        {
                            listPatentesAElegir.Items.Add(patenteAcceso);
                        }
                    }
                }
            }

            // 3. Reagregar las patentes necesarias a la familia padre.
            // Esto asegura que si se quitaron las patentes "Usuario" y "Gestionar Usuario", se vuelvan a asignar.
            AñadirPatenteNecesaria(familiaPadre);

            MessageBox.Show($"Se eliminó del Rol {familiaPadre.Nombre} el Rol {familiaHija.Nombre}, junto con sus accesos.");
            this.Refresh();
        }



        public void CargarFamiliasdeFamiliaParaEliminar(ref Familia familiaPadre, ref Familia familiaHija)
        {
            // Asignar familiaPadre desde la lista seleccionada o desde el TextBox
            if (listFamilias.SelectedItem != null && listFamiliasElegidasRol.SelectedItem != null)
            {
                familiaPadre = listFamilias.SelectedItem as Familia;
                familiaHija = listFamiliasElegidasRol.SelectedItem as Familia;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtRolSeleccionado.Text))
                {
                    familiaPadre = new Familia { Nombre = txtRolSeleccionado.Text };
                }
                else
                {
                    MessageBox.Show("Debe seleccionar o ingresar el nombre de la familia padre.");
                    return;
                }
            }

            // Obtener todas las familias
            todasLasFamilias = familiaLogic.GetAllFamilias();

            // Validar que ambas familias sean seleccionadas
            if (familiaPadre == null || familiaHija == null)
            {
                MessageBox.Show("Debe seleccionar ambas familias.");
                return;
            }
        }

        private void btnRemoveFamiliaPatente_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                Familia familiaPadre = null;
                Patente patenteHija = null;
                CargarPatentesdeFamiliaParaEliminar(ref familiaPadre, ref patenteHija);

                // Lanzamos la excepción si la patente es "Usuario" o "Gestionar Usuario"
                if (patenteHija.Nombre == "Usuario" || patenteHija.Nombre == "Gestionar Usuario")
                {
                    throw new PatenteNoRemovibleException(patenteHija.Nombre);
                }

                // Si no se lanza la excepción, procedemos con la eliminación normal
                familiaLogic.Delete(familiaPadre, patenteHija);
                listPatentesElegidas.Items.Remove(patenteHija);
                if (!listPatentesAElegir.Items.Contains(patenteHija))
                {
                    listPatentesAElegir.Items.Add(patenteHija);
                }

                MessageBox.Show($"Se eliminó del Rol {familiaPadre.Nombre} la patente {patenteHija.Nombre}.");
                FmrAccesos fmr = new FmrAccesos(usuarioActual);
                fmr.Refresh();
            }
            catch (PatenteNoRemovibleException ex)
            {
                // Aquí capturamos la excepción personalizada y mostramos el mensaje al usuario
                MessageBox.Show(ex.Message, "Acceso no removible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Manejo genérico de otras excepciones
                MessageBox.Show($"Ocurrió un error al intentar eliminar la patente: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarPatentesdeFamiliaParaEliminar(ref Familia familiaPadre, ref Patente patenteHija)
        {
            // Asignar familiaPadre desde la lista seleccionada o desde el TextBox
            if (listFamilias.SelectedItem != null && listPatentesElegidas.SelectedItem != null)
            {
                familiaPadre = listFamilias.SelectedItem as Familia;
                patenteHija = listPatentesElegidas.SelectedItem as Patente;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtRolSeleccionado.Text))
                {
                    familiaPadre = new Familia { Nombre = txtRolSeleccionado.Text };
                }
                else
                {
                    MessageBox.Show("Debe seleccionar o ingresar el nombre de la familia padre.");
                    return;
                }
            }
            todasLasFamilias = familiaLogic.GetAllFamilias();
            if (familiaPadre == null || patenteHija == null)
            {
                MessageBox.Show("Debe seleccionar ambas familias.");
                return;
            }
        }


        #endregion

        #region Eliminar Rol
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarConexion())
                    return;
                // Verificar si hay una familia seleccionada
                if (listFamilias.Items.Count > 0)
                {
                    Familia familia = listFamilias.SelectedItem as Familia;
                    if (familia == null)
                    {
                        // No hay familia seleccionada
                        MessageBox.Show("Por favor, selecciona una familia para eliminar.",
                            "Advertencia", MessageBoxButtons.OK);
                        return;
                    }

                    // Lanzamos la excepción si la familia es "Sin Rol"
                    if (familia.Nombre == "Sin Rol")
                    {
                        throw new FamiliaNoEliminableException(familia.Nombre);
                    }

                    // Confirmar eliminación
                    var confirmResult = MessageBox.Show($"¿Estás seguro de que deseas eliminar la familia '{familia.Nombre}'?",
                                                        "Confirmar eliminación",
                                                        MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        FamiliaLogic.Instance.Eliminar(familia.Id);
                        MessageBox.Show("Familia eliminada correctamente.", "Éxito", MessageBoxButtons.OK);
                        LimpiarListBox();
                        CargarTodosLosAccesos();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una familia para eliminar.", "Advertencia", MessageBoxButtons.OK);
                }
            }
            catch (FamiliaNoEliminableException ex)
            {
                // Capturamos la excepción personalizada
                MessageBox.Show(ex.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Manejo genérico de excepciones
                MessageBox.Show($"Error al eliminar la familia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion


    }
}