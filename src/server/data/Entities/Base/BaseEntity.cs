using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistre.Data.Entities.Base;

public class BaseEntity
{
    public int Id { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

}
