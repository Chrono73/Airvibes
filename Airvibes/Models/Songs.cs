//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Airvibes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Songs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Songs()
        {
            this.SComment = new HashSet<SComment>();
        }
    
        public int Id { get; set; }
        public int Id_Artist { get; set; }
        public int Id_Record { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int TimesPlayed { get; set; }
        public Nullable<int> Rating { get; set; }
        public byte[] LowQFile { get; set; }
        public byte[] HiQFile { get; set; }
    
        public virtual Artists Artists { get; set; }
        public virtual Records Records { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SComment> SComment { get; set; }
    }
}