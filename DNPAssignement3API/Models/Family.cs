using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models
{
    public class Family
    {
        //public int Id { get; set; }
        [Required, MaxLength(10)]
        public string StreetName { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int HouseNumber { get; set; }
        
        public int FamilyId { get; set; }
        
        public List<Adult> Adults { get; set; }
        public List<Child> Children { get; set; }
        public List<Pet> Pets { get; set; }

        public Family()
        {
            Adults = new List<Adult>();
        }
        
        public string GetFamilyName()
        {
            string familyName = "";
            if (Adults.Any())
            {
                foreach (Adult adult in Adults)
                {
                    if (familyName.Contains(adult.LastName))
                    {
                        continue;
                    }
                    familyName += adult.LastName + " ";
                }
                familyName.Remove(familyName.Length - 1);
            }
            
            return familyName;
        }
        

    }
}