namespace Controladora.Seguridad_composite
{
    public class PermisoSimple : PermisoComponent
    {
        private readonly string _nombrePermiso;

        public PermisoSimple(string nombrePermiso)
        {
            _nombrePermiso = nombrePermiso;
        }

        public override void Add(PermisoComponent component)
        {
            throw new System.NotImplementedException();
        }

        public override void Remove(PermisoComponent component)
        {
            throw new System.NotImplementedException();
        }
        public override bool valiPermiso(string permissionName)
        {
            throw new System.NotImplementedException();
        }
    }
}
