using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfBase.Infrastructure.Framework
{
    public class EntityBase : INotifyPropertyChanged
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
