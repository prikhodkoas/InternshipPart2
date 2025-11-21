using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace XMLNotes
{
    public class NoteDto
    {
        [Browsable(false)]
        public string Id {  get; set; }

        [Browsable(true)]
        [DisplayName("Название задачи")]
        public string Title { get; set; }

        [Browsable(true)]
        [DisplayName("Описание задачи")]
        public string Description { get; set; }
        
        [Browsable(true)]
        [DisplayName("Последнее обновление")]
        public DateTime UpdatedAt { get; set; }
    }
}
