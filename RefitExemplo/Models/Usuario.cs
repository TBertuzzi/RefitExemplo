using System;
namespace RefitExemplo.Models
{
    public partial class Usuario
    {
        public long UserId { get; set; }

        public long Id { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }
    }
}
