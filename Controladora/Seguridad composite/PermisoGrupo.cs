using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Seguridad_composite
{
    public class PermisoGrupo : PermisoComponent
    {
        private readonly List<PermisoComponent> _components = new List<PermisoComponent>();

        public override void Add(PermisoComponent component)
        {
            _components.Add(component);
        }

        public override void Remove(PermisoComponent component)
        {
            _components.Remove(component);
        }

        public override bool HasPermission(string permissionName)
        {
            return _components.Any(c => c.HasPermission(permissionName));
        }
    }
}
