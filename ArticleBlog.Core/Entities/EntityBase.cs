using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual int ID { get; set; }
        public virtual string CreatedBy { get; set; } = "Undefined";//article kim tarafından yaratıldı?
        public virtual string? ModifiedBy { get; set; }//article kim tarafından düzenlendi?. Null geçilebilir (?) yaptık.
        public virtual string? DeletedBy { get; set; }//article kim tarafından silindi?. Null geçilebilir (?) yaptık.
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now; //article yaratma tarihi.
        public virtual DateTime? ModifiedDate { get; set; }//article düzenleme tarihi. Null geçilebilir (?) yaptık.
        public virtual DateTime? DeletedDate { get; set; } //article silinme tarihi. Null geçilebilir (?) yaptık.
        public virtual bool IsDeleted { get; set; } = false; //article silinmiş mi?
    }
}
