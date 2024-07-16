using Controladora.Seguridad_composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Vista.Seguridad
{
    public partial class PermisosUsuario : Form
    {
        private static PermisosUsuario instancia;
        private Controladora.Usuario cUsuario = Controladora.Usuario.Obtener_instancia();
        private Modelo.Usuarios usuario;
        private int id_usuario;

        private List<Modelo.Permisos> permisosUsuario;
        private List<Modelo.Permisos> nuevosPermisosUsuario = new List<Modelo.Permisos>();
        private List<Modelo.Permisos> eliminarPermisosUsuario = new List<Modelo.Permisos>();
        private List<Modelo.Permisos> nuevosGruposUsuario = new List<Modelo.Permisos>();
        private List<Modelo.Permisos> eliminarGruposUsuario = new List<Modelo.Permisos>();
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

        public static PermisosUsuario Obtener_instancia(int id_usuario)
        {
            if (instancia == null)
                instancia = new PermisosUsuario(id_usuario);

            if (instancia.IsDisposed)
                instancia = new PermisosUsuario(id_usuario);

            instancia.BringToFront();
            return instancia;
        }
        public PermisosUsuario(int id_usuario)
        {
            InitializeComponent();
            CargarPermisos();
            this.id_usuario = id_usuario;
            if (id_usuario != 0)
            {
                usuario = cUsuario.getUsuarioId(id_usuario).FirstOrDefault();
                permisosUsuario = cPermiso.getPermisosUsuario(id_usuario);
                txtnombre.Text = usuario.nombre;
                txtemail.Text = usuario.email;
                txtape.Text = usuario.apellido;
                txtdni.Text = usuario.dni;
                checkEstado.Checked = (bool)usuario.estado;
                MarcarPermisos(treeViewPermisos.Nodes, permisosUsuario);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (id_usuario == 0)
            {
                usuario = new Modelo.Usuarios();
                usuario.nombre = txtnombre.Text;
                usuario.email = txtemail.Text;
                usuario.apellido = txtape.Text;
                usuario.dni = txtdni.Text;
                usuario.estado = checkEstado.Checked;
                cUsuario.agregarUsuario(usuario);
            }
            else
            {
                usuario.id_usuario = id_usuario;
                usuario.nombre = txtnombre.Text;
                usuario.email = txtemail.Text;
                usuario.apellido = txtape.Text;
                usuario.dni = txtdni.Text;
                usuario.estado = checkEstado.Checked;
                cUsuario.modificarUsuario(usuario);
            }
            MessageBox.Show("Usuario guardado con exito");
            this.Close();
        }

        private void treeViewPermisos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Obtener el permiso asociado al nodo
            Modelo.Permisos permiso = listpermisos.Where(p => p.nombre_permiso == e.Node.Text).FirstOrDefault();

            if (permiso != null)
            {
                if (e.Node.Checked)
                {
                    if (!permisosUsuario.Any(p => p.id_permiso == permiso.id_permiso))
                    {
                        nuevosPermisosUsuario.Add(permiso);
                        eliminarPermisosUsuario.Remove(permiso);
                    }
                }
                else
                {
                    if (permisosUsuario.Any(p => p.id_permiso == permiso.id_permiso))
                    {
                        eliminarPermisosUsuario.Add(permiso);
                        nuevosPermisosUsuario.Remove(permiso);
                    }
                    else
                    {
                        eliminarPermisosUsuario.Remove(permiso);
                    }
                }
            }
        }
    }
}
