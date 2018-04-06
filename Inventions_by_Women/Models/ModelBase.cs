using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventions_by_Women.Models
{
    public abstract class ModelBase
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid ID { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime UpdatedAt { get; set; }

            public DateTime? DeletedAt { get; set; }

            public bool Deleted { get; set; }
        }
}