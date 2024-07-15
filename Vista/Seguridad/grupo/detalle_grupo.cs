using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Vista.Seguridad
{
    public partial class detalle_grupo : Form
    {
        private int idGrupo;
        private static detalle_grupo instancia;
        private List<Modelo.Permisos> permisosGrupo;
        private List<Modelo.Permisos> nuevosPermisosGrupo = new List<Modelo.Permisos>();
        private List<Modelo.Permisos> eliminarPermisoGrupo = new List<Modelo.Permisos>();
        //Grupo
        private Controladora.Seguridad.Grupo cGrupo = Controladora.Seguridad.Grupo.Obtener_instancia();
        private Modelo.Grupos grupo;
        //Permiso
        private Controladora.Seguridad.Permiso cPermiso = Controladora.Seguridad.Permiso.Obtener_instancia();
        List<Modelo.Permisos> listpermisos;
        //Modulo
        private Controladora.Seguridad.Modulo cModulo = Controladora.Seguridad.Modulo.Obtener_instancia();
        //Formulario
        private Controladora.Seguridad.Formulario cFormulario = Controladora.Seguridad.Formulario.Obtener_instancia();

        public static detalle_grupo Obtener_instancia(int id)
        {
            if (instancia == null)
                instancia = new detalle_grupo(id);

            if (instancia.IsDisposed)
                instancia = new detalle_grupo(id);

            instancia.BringToFront();
            return instancia;
        }


        public detalle_grupo(int id)
        {
            InitializeComponent();
            CargarPermisos();
            checkEstado.Checked = true;

            if (id != 0)
            {
                this.idGrupo = id;
                permisosGrupo = cPermiso.getPermisosGrupo(id);
                grupo = cGrupo.getGrupoId(id).FirstOrDefault();
                checkEstado.Checked = (bool)grupo.estado;
                txtnombre.Text = grupo.grupo_nombre;
                MarcarPermisos(treeViewPermisos.Nodes, permisosGrupo);
            }
        }

        private void MarcarPermisos(TreeNodeCollection nodes, List<Modelo.Permisos> permisosGrupos)
        {
            foreach (TreeNode node in nodes)
            {
                // Verificar si el nombre del permiso del nodo está en la lista de permisos del usuario
                if (permisosGrupos.Any(permiso => permiso.nombre_permiso == node.Text))
                {
                    node.Checked = true; // Marcar el checkbox del nodo
                }
                // Llamar recursivamente a la función para los nodos hijos
                MarcarPermisos(node.Nodes, permisosGrupos);
            }
        }

        private void CargarPermisos()
        {
            try
            {
                // Limpiar nodos previos
                treeViewPermisos.Nodes.Clear();

                // Obtener todos los módulos, formularios y permisos
                List<Modelo.Modulos> listmodulos = cModulo.getModulos();
                List<Modelo.Formularios> listformularios = cFormulario.getFormularios();
                listpermisos = cPermiso.getPermisos();

                // Iterar sobre cada módulo
                foreach (Modelo.Modulos modulo in listmodulos)
                {
                    // Crear nodo de módulo
                    TreeNode moduloNode = new TreeNode(modulo.nombre);
                    moduloNode.Tag = modulo.id_modulo;

                    // Iterar sobre cada formulario
                    foreach (Modelo.Formularios formulario in listformularios)
                    {
                        // Verificar si el formulario pertenece al módulo actual
                        if (formulario.id_modulo == modulo.id_modulo)
                        {
                            // Crear nodo de formulario
                            TreeNode formularioNode = new TreeNode(formulario.nombre);

                            // Iterar sobre cada permiso
                            foreach (Modelo.Permisos permiso in listpermisos)
                            {
                                // Verificar si el permiso pertenece al formulario actual
                                if (permiso.id_formulario == formulario.id_formulario)
                                {
                                    // Agregar nodo de permiso al nodo de formulario
                                    formularioNode.Nodes.Add(new TreeNode(permiso.nombre_permiso));
                                }
                            }

                            // Agregar nodo de formulario al nodo de módulo
                            moduloNode.Nodes.Add(formularioNode);
                        }
                    }

                    // Agregar nodo de módulo al TreeView
                    treeViewPermisos.Nodes.Add(moduloNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idGrupo == 0)
            {
                //logica para hacer un add group
                grupo = new Modelo.Grupos();
                grupo.grupo_nombre = txtnombre.Text;
                grupo.estado = checkEstado.Checked;
                cGrupo.agregarGrupo(grupo, nuevosPermisosGrupo);
            }
            else
            {
                //logica para modificar un grupo
                grupo = cGrupo.getGrupoId(idGrupo).FirstOrDefault();
                grupo.grupo_nombre = txtnombre.Text;
                grupo.estado = checkEstado.Checked;
                cGrupo.modificarGrupo(grupo, nuevosPermisosGrupo, eliminarPermisoGrupo);
            }
            // Guardar los permisos seleccionados para el grupo
            nuevosPermisosGrupo.Clear();
            eliminarPermisoGrupo.Clear();

            this.Close();
            MessageBox.Show("Permisos guardados correctamente.");
        }

        private void treeViewPermisos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Obtener el permiso asociado al nodo
            Modelo.Permisos permiso = listpermisos.Where(p => p.nombre_permiso == e.Node.Text).FirstOrDefault();

            if (permiso != null)
            {
                if (e.Node.Checked)
                {
                    if (!permisosGrupo.Any(p => p.id_permiso == permiso.id_permiso))
                    {
                        nuevosPermisosGrupo.Add(permiso);
                        eliminarPermisoGrupo.Remove(permiso);
                    }
                }
                else
                {
                    if (permisosGrupo.Any(p => p.id_permiso == permiso.id_permiso))
                    {
                        eliminarPermisoGrupo.Add(permiso);
                        nuevosPermisosGrupo.Remove(permiso);
                    }
                    else
                    {
                        eliminarPermisoGrupo.Remove(permiso);
                    }
                }
            }
        }
    }
}