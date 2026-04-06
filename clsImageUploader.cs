using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module2LogonView
{
    /// <summary>
    /// Provides functionality for uploading and verifying inventory images
    /// in the database.
    /// </summary>
    public static class clsImageUploader
    {
        /// <summary>
        /// Uploads missing inventory images from a specified folder to the database.
        /// Only images that do not already exist in the database will be uploaded.
        /// </summary>
        /// <param name="imageFolderPath">
        /// The file path to the folder containing image files named by inventory ID.
        /// </param>
        public static void BulkUploadImagesIfMissing(string imageFolderPath)
        {
            try
            {
                for (int inventoryID = 100; inventoryID <= 124; inventoryID++)
                {
                    if (ImageExistsInDatabase(inventoryID))
                        continue;

                    string filePath = Path.Combine(imageFolderPath, $"{inventoryID}.jpg");

                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show($"Image not found: {filePath}");
                        continue;
                    }

                    byte[] imageBytes = File.ReadAllBytes(filePath);

                    string query = @"
                        UPDATE Inventory
                        SET ItemImage = @img
                        WHERE InventoryID = @id";

                    clsSQL.ExecuteNonQuery(
                        query,
                        new SQLiteParameter("@img", imageBytes),
                        new SQLiteParameter("@id", inventoryID)
                    );
                }

                MessageBox.Show("Missing images uploaded successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading images: " + ex.Message);
            }
        }

        /// <summary>
        /// Checks whether an image exists in the database for a given inventory item.
        /// </summary>
        /// <param name="inventoryID">The inventory item identifier.</param>
        /// <returns>
        /// True if an image exists; otherwise, false.
        /// </returns>
        private static bool ImageExistsInDatabase(int inventoryID)
        {
            string query = "SELECT ItemImage FROM Inventory WHERE InventoryID = @id";

            object result = clsSQL.ExecuteScalar(
                query,
                new SQLiteParameter("@id", inventoryID)
            );

            return result != null && result != DBNull.Value;
        }

        /// <summary>
        /// Determines whether all inventory items in the specified range
        /// have images stored in the database.
        /// </summary>
        /// <param name="startId">The starting inventory ID.</param>
        /// <param name="endId">The ending inventory ID.</param>
        /// <returns>
        /// True if all items have images; otherwise, false.
        /// </returns>
        public static bool AllImagesExist(int startId, int endId)
        {
            for (int inventoryID = startId; inventoryID <= endId; inventoryID++)
            {
                if (!ImageExistsInDatabase(inventoryID))
                    return false;
            }
            return true;
        }
    }
}
