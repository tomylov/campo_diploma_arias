using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override bool HasPermission(string permissionName)
        {
            return _nombrePermiso.Equals(permissionName, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
