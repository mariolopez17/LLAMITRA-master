﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LlamitraApi.Models
{
    [Table("Publications")]
    public class Publication
    {
        public int IdPublication { get; set; }
        public int IdType { get; set; }
        public int IdUser {  get; set; }
        public string Professor { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public virtual PublicationType IdTypeNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }

    }
}
