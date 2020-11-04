/*
    Name: João Rodrigues
    Student no.: 16928
    University: IPCA
    Subject: Integration of Informatic Sistems
    Objective: Manipulate informations from IPMA's metereology
    Created at: 28/10/20
    
    Class: Local 
    Aim: Define a local, in order to save each local's id, to match metereology with the respective district / island 
 */

using System;
using System.Linq;

namespace BusinessObjects
{
    [Serializable]
    public class Local
    {
        string name;
        int id;

        // globalIdLocal  =>  id of district/island
        public int Id { get { return id; } set { id = value; } }
        
        // Name of district/island
        public string Name { 
            get { return name; } 
            set { name = value;} // checking if received value has only 
        }
    }
}
