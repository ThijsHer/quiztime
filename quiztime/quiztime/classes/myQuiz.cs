using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace quiztime.classes
{
    public class myQuiz
    {
        public myQuiz() { }

        public string Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<myQuiz> MyList { get; set; }
    }
}
