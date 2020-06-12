using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotattion.EntityConfiguration
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            //there are protocol to set the property in such way 

            //1.set table name
            ToTable("CoursesDetail");

            //2.set Primary key
            HasKey(c => c.Id);

            //3.set property
            Property(c => c.description)
          .IsRequired()
          .HasMaxLength(2000);

            Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255);


            //4.set relationship

            // one to many relation ship couse -> author
            HasRequired(c => c.Author) // has required one author
            .WithMany(a => a.Courses)// author has many course
            .HasForeignKey(c => c.authorId)// set foreignkey
            .WillCascadeOnDelete(false);// foreign key so could not delete reference record set false so user can delete the record

            //Many to Many relationship course -> tag
            HasMany(c => c.Tags)// course hasmany tag
            .WithMany(t => t.Courses)//tag hasmany course
                                     // .Map(m => m.ToTable("CourseTags"));//set table convience table name 
           .Map(m =>
           {
               m.ToTable("CourseTag");
               m.MapLeftKey("CourseID");//change the name Course_id to CourseID
               m.MapRightKey("TagID");// change the name Tag_id to TagID
           });

            // one to one relationship corse -> cover
            HasRequired(c => c.cover) // corse gas required one cover
            .WithRequiredPrincipal(v => v.course);// in one to one relshp 1 principle(course) 1 dependent(cover)
                                                  // so cover require principle ->course  
        }
    }
}
