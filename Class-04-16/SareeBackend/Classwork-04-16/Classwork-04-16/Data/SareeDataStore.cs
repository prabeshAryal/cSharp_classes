// File: Data/SareeDataStore.cs
using Classwork_04_16.Models; // Use your actual project's namespace
using System.Collections.Generic;
using System.Linq;

namespace Classwork_04_16.Data // Use your actual project's namespace + .Data
{
    public static class SareeDataStore
    {
        private static List<Saree> _sarees;
        private static int _nextId = 4; // Start ID after the initial data

        // Static constructor to initialize data only once
        static SareeDataStore()
        {
            _sarees = new List<Saree>()
            {
                new Saree {
                    Id = 1, Name = "Classic Kanjeevaram", Material = "Silk", Color = "Royal Blue", Price = 150.00M,
                    Description = "Traditional pure silk saree with gold zari border.",
                    Image = "/images/sarees/kanjeevaram_blue.jpg" // Example image path/URL
                    },
                new Saree {
                    Id = 2, Name = "Elegant Banarasi", Material = "Georgette", Color = "Emerald Green", Price = 120.50M,
                    Description = "Lightweight georgette with intricate Banarasi weave.",
                    Image = "/images/sarees/banarasi_green.jpg" // Example image path/URL
                    },
                new Saree {
                    Id = 3, Name = "Comfort Cotton", Material = "Cotton", Color = "Sunshine Yellow", Price = 55.75M,
                    Description = "Breathable cotton saree perfect for daily wear.",
                    Image = null // Example with no image
                    }
            };
        }

        public static List<Saree> GetSarees()
        {
            return new List<Saree>(_sarees);
        }

        public static Saree? GetSareeById(int id)
        {
            return _sarees.FirstOrDefault(s => s.Id == id);
        }

        public static Saree AddSaree(Saree saree)
        {
            saree.Id = _nextId++;
            // The Image property is already part of the 'saree' object passed in
            _sarees.Add(saree);
            return saree;
        }

        public static bool UpdateSaree(int id, Saree updatedSaree)
        {
            var existingSaree = _sarees.FirstOrDefault(s => s.Id == id);
            if (existingSaree == null)
            {
                return false;
            }

            // Update properties INCLUDING Image
            existingSaree.Name = updatedSaree.Name;
            existingSaree.Material = updatedSaree.Material;
            existingSaree.Color = updatedSaree.Color;
            existingSaree.Price = updatedSaree.Price;
            existingSaree.Description = updatedSaree.Description;
            existingSaree.Image = updatedSaree.Image; // <-- Make sure to update the image property

            return true;
        }

        public static bool DeleteSaree(int id)
        {
            var sareeToRemove = _sarees.FirstOrDefault(s => s.Id == id);
            if (sareeToRemove == null)
            {
                return false;
            }

            _sarees.Remove(sareeToRemove);
            return true;
        }
    }
}