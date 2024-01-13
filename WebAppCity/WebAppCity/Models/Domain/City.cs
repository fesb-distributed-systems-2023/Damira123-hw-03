/*
**********************************
* Author: Damira Mamuzić
* Project Task: City - Phase 1
**********************************
* Description:
*  
*  Contains Model defining City class 
*
**********************************
*/

namespace WebAppCity.Models.Domain
{
    public class City
    {

        // id za svaki grad
        public int Id { get; set; }

        // gradonačelnik grada
        public string? Mayor { get; set; }

        //Godina nastanka grada
        public int? Year { get; set; }

        //Država u kojoj se nalazi
        public string? Country { get; set; }

       // broj stanovništva
        public int Population { get; set; }

        // lista znamenitosti grada
        public List<string>? Monuments { get; set; }




    }
}
