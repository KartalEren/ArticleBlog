using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Core.Entities
{
    public interface IEntityBase//EntityBase classına açıkta bırakmamak adına bu interfaceye bağladık. EntityBase classına kalıtım verdik. Sonuç olarak her entitiyler bir Interface sınıfdan kalıtım almalıdır ve normal classlar böylece açıkta kalmazlar.
    {
    }
}
