using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Seguridad_composite
{
    public abstract class PermisoComponent
    {
        public abstract void Add(PermisoComponent component);
        public abstract void Remove(PermisoComponent component);
        public abstract bool HasPermission(string permissionName);
    }
}
