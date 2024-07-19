using Controladora.Seguridad_composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;

namespace Vista.Seguridad
{
    public partial class detalle_usuario : Form
    {
        private static detalle_usuario instancia;
        private Controladora.Usuario cUsuario = Controladora.Usuario.Obtener_instancia();
        private Modelo.Usuarios usuario;
        private int id_usuario;

        private List<Modelo.Permisos> listpermisos;
        private List<Modelo.Permisos> permisosUsuario;
        //grupo usuario
        private List<Modelo.Grupos> gruposUsuarioInicial = new List<Modelo.Grupos>();
        private BindingList<Modelo.Grupos> gruposDisponibles;
        private BindingList<Modelo.Grupos> gruposUsuario;
        //Grupo
        private Controladora.Seguridad.Grupo cGrupo = Controladora.Seguridad.Grupo.Obtener_instancia();
        //Permiso
        private Controladora.Seguridad.Permiso cPermiso = Controladora.Seguridad.Permiso.Obtener_instancia();
        //Modulo
        private Controladora.Seguridad.Modulo cModulo = Controladora.Seguridad.Modulo.Obtener_instancia();
        //Formulario
        private Controladora.Seguridad.Formulario cFormulario = Controladora.Seguridad.Formulario.Obtener_instancia();

        public static detalle_usuario Obtener_instancia(int id_usuario)
        {
            if (instancia == null)
                instancia = new detalle_usuario(id_usuario);

            if (instancia.IsDisposed)
                instancia = new detalle_usuario(id_usuario);

            instancia.BringToFront();
            return instancia;
        }
        public detalle_usuario(int id_usuario)
        {
            InitializeComponent();
            CargarPermisos();
            this.id_usuario = id_usuario;
            if (id_usuario != 0)
            {
                permisosUsuario = cPermiso.getPermisosUsuario(id_usuario);
                //lista de grupos del usuario
                gruposUsuario = new BindingList<Modelo.Grupos>(cGrupo.getGruposUsuarios(id_usuario));
                //lista de grupos disponibles
                List<Modelo.Grupos> gruposDisponiblesFiltrados = new List<Modelo.Grupos>(cGrupo.getGrupos().Where(g => g.estado == true));
                gruposDisponibles = new BindingList<Modelo.Grupos>(gruposDisponiblesFiltrados);
                //se quitan los grupos que ya tiene el usuario
                foreach (Modelo.Grupos grupo in gruposUsuario)
                {
                    gruposDisponibles.Remove(grupo);
                }
                dataGruposDisponibles.DataSource = gruposDisponibles;
                estilosDataGrid(dataGruposDisponibles);
                
                dataGruposMiembro.DataSource = gruposUsuario;
                estilosDataGrid(dataGruposMiembro);
                
                usuario = cUsuario.getUsuarioId(id_usuario).FirstOrDefault();
                txtnombre.Text = usuario.nombre;
                txtemail.Text = usuario.email;
                txtape.Text = usuario.apellido;
                txtdni.Text = usuario.dni;
                checkEstado.Checked = (bool)usuario.estado;
                MarcarPermisos(treeViewPermisos.Nodes, permisosUsuario);
            }
        }

        private void estilosDataGrid(DataGridView data)
        {
            data.Columns[0].Visible = false;
            data.Columns[3].Visible = false;
            data.Columns[4].Visible = false;
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
                listpermisos = cPermiso.getPermisos().Where(p => p.estado == true).ToList();

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
                usuario.Permisos = permisosUsuario;
                usuario.Grupos = gruposUsuario;
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
                usuario.Permisos = permisosUsuario;
                usuario.Grupos = gruposUsuario;
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
                    permisosUsuario.Add(permiso);
                }
                else
                {
                    permisosUsuario.Remove(permiso);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGruposDisponibles.SelectedRows.Count > 0)
            {
                var currentRow = dataGruposDisponibles.CurrentRow;
                if (currentRow != null)
                {
                    Modelo.Grupos grupo = (Modelo.Grupos)currentRow.DataBoundItem;
                    gruposDisponibles.Remove(grupo);
                    gruposUsuario.Add(grupo);
                }
            }

            estilosDataGrid(dataGruposDisponibles);
            estilosDataGrid(dataGruposMiembro);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGruposMiembro.SelectedRows.Count > 0)
            {
                var currentRow = dataGruposMiembro.CurrentRow;
                if (currentRow != null)
                {
                    Modelo.Grupos grupo = (Modelo.Grupos)currentRow.DataBoundItem;
                    gruposUsuario.Remove(grupo);
                    gruposDisponibles.Add(grupo);
                }
            }
            estilosDataGrid(dataGruposDisponibles);
            estilosDataGrid(dataGruposMiembro);
        }
    }
}
