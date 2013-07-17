using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Table("Homeworks")]
public class Homework
{
    [Key]
    public int HomeworkID { get; set; }
    public string HomeworkContent { get; set; }
    public DateTime TimeSent { get; set; }

    [ForeignKey("Course")]
    public int CourseId { get; set; }
    [ForeignKey("Student")]
    public int StudentId { get; set; }

    public virtual Student Student { get; set; }
    public virtual Course Course { get; set; }
}

