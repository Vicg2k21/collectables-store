using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module2LogonView
{
    /// <summary>
    /// Provides database access methods for executing SQL commands,
    /// retrieving data, and managing the SQLite connection.
    /// </summary>
    internal class clsSQL
    {
        /// <summary>
        /// Connection string used to connect to the SQLite database.
        /// The database is stored in a writable local application data folder.
        /// </summary>
        private static readonly string CONNECT_STRING =
            $"Data Source={GetWritableDbPath()};Version=3;";

        /// <summary>
        /// Retrieves the writable database file path. If the database does not exist
        /// in the local application data directory, it is copied from the installation folder.
        /// </summary>
        /// <returns>
        /// A string representing the full file path to the writable SQLite database.
        /// </returns>
        private static string GetWritableDbPath()
        {
            string appDataFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Module2SQLite"
            );

            if (!Directory.Exists(appDataFolder))
                Directory.CreateDirectory(appDataFolder);

            string dbPath = Path.Combine(appDataFolder, "CollectablesDB.db");

            // Copy the DB from install folder on first run
            if (!File.Exists(dbPath))
            {
                string installedDb = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "CollectablesDB.db"
                );

                File.Copy(installedDb, dbPath);
            }

            return dbPath;
        }

        /// <summary>
        /// Executes a SQL query that returns a single value.
        /// </summary>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="parameters">Optional SQL parameters.</param>
        /// <returns>
        /// The first column of the first row in the result set,
        /// or null if an error occurs.
        /// </returns>
        public static object ExecuteScalar(string sql, params SQLiteParameter[] parameters)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(CONNECT_STRING))
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("SQLite Error: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Executes a SQL command that modifies data such as INSERT, UPDATE, or DELETE.
        /// </summary>
        /// <param name="sql">The SQL command to execute.</param>
        /// <param name="parameters">Optional SQL parameters.</param>
        /// <returns>
        /// The number of rows affected, or -1 if an error occurs.
        /// </returns>
        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] parameters)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(CONNECT_STRING))
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("SQLite Error: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Executes a SQL query and returns the results as a DataTable.
        /// </summary>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="parameters">Optional SQL parameters.</param>
        /// <returns>
        /// A DataTable containing the query results, or null if an error occurs.
        /// </returns>
        private static DataTable GetDataTable(string sql, params SQLiteParameter[] parameters)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(CONNECT_STRING))
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("SQLite Error: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Authenticates a user by verifying their username and password
        /// against the database and returns their role.
        /// </summary>
        /// <param name="username">The username entered by the user.</param>
        /// <param name="password">The password entered by the user.</param>
        /// <returns>
        /// The user's position title if authentication is successful;
        /// otherwise, null if authentication fails.
        /// </returns>
        public static string AuthenticateUser(string username, string password)
        {
            string sql = @"
                SELECT PositionTitle
                FROM Logon
                WHERE LOWER(LogonName) = LOWER(@username)
                  AND Password = @password
                  AND IFNULL(AccountDeleted, 0) = 0
                  AND IFNULL(AccountDisabled, 0) = 0";

            object result = ExecuteScalar(sql,
                new SQLiteParameter("@username", username),
                new SQLiteParameter("@password", password));

            return result?.ToString();
        }

        /// <summary>
        /// Checks whether a username already exists in the system.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>
        /// True if the username is already taken; otherwise false.
        /// </returns>
        public static bool IsUsernameTaken(string username)
        {
            string sql = @"SELECT COUNT(*) FROM Logon WHERE LOWER(LogonName) = LOWER(@username)";
            object result = ExecuteScalar(sql, new SQLiteParameter("@username", username));
            return Convert.ToInt32(result) > 0;
        }

        /// <summary>
        /// Retrieves all available positions from the database.
        /// </summary>
        /// <returns>
        /// A DataTable containing PositionID and PositionTitle values.
        /// </returns>
        public static DataTable GetPositions()
        {
            string sql = "SELECT PositionID, PositionTitle FROM Position";
            return GetDataTable(sql);
        }

        /// <summary>
        /// Retrieves all security questions associated with a specific set.
        /// </summary>
        /// <param name="setId">The identifier for the question set.</param>
        /// <returns>
        /// A DataTable containing the security questions for the specified set.
        /// </returns>
        public static DataTable GetSecurityQuestionsBySet(int setId)
        {
            string sql = "SELECT QuestionID, QuestionPrompt FROM SecurityQuestions WHERE SetID = @SetID";
            return GetDataTable(sql, new SQLiteParameter("@SetID", setId));
        }

        /// <summary>
        /// Retrieves the three security questions assigned to a specific user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>
        /// A DataRow containing the user's three security questions,
        /// or null if the user is not found.
        /// </returns>
        public static DataRow GetSecurityQuestionsForUser(string username)
        {
            string sql = @"
        SELECT 
            cq1.QuestionID AS Q1ID, cq1.QuestionPrompt AS Q1Prompt,
            cq2.QuestionID AS Q2ID, cq2.QuestionPrompt AS Q2Prompt,
            cq3.QuestionID AS Q3ID, cq3.QuestionPrompt AS Q3Prompt
        FROM Logon L
        JOIN SecurityQuestions cq1 ON L.FirstChallengeQuestion = cq1.QuestionID
        JOIN SecurityQuestions cq2 ON L.SecondChallengeQuestion = cq2.QuestionID
        JOIN SecurityQuestions cq3 ON L.ThirdChallengeQuestion = cq3.QuestionID
        WHERE LOWER(L.LogonName) = LOWER(@username)";

            DataTable dt = GetDataTable(sql, new SQLiteParameter("@username", username));
            return dt?.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Verifies that the provided security question answers match
        /// the stored answers for the specified user.
        /// </summary>
        /// <param name="username">The username of the account.</param>
        /// <param name="q1ID">The ID of the first security question.</param>
        /// <param name="a1">The answer to the first security question.</param>
        /// <param name="q2ID">The ID of the second security question.</param>
        /// <param name="a2">The answer to the second security question.</param>
        /// <param name="q3ID">The ID of the third security question.</param>
        /// <param name="a3">The answer to the third security question.</param>
        /// <returns>
        /// True if all security question answers match the database records;
        /// otherwise, false.
        /// </returns>
        public static bool VerifySecurityAnswers(
    string username,
    int q1ID, string a1,
    int q2ID, string a2,
    int q3ID, string a3)
        {
            string sql = @"
        SELECT COUNT(*)
        FROM Logon
        WHERE LOWER(LogonName) = LOWER(@username)
          AND FirstChallengeQuestion = @Q1 AND LOWER(FirstChallengeAnswer) = LOWER(@A1)
          AND SecondChallengeQuestion = @Q2 AND LOWER(SecondChallengeAnswer) = LOWER(@A2)
          AND ThirdChallengeQuestion = @Q3 AND LOWER(ThirdChallengeAnswer) = LOWER(@A3);";

            object result = ExecuteScalar(sql,
                new SQLiteParameter("@username", username),
                new SQLiteParameter("@Q1", q1ID),
                new SQLiteParameter("@A1", a1.Trim()),
                new SQLiteParameter("@Q2", q2ID),
                new SQLiteParameter("@A2", a2.Trim()),
                new SQLiteParameter("@Q3", q3ID),
                new SQLiteParameter("@A3", a3.Trim())
            );

            return Convert.ToInt32(result) == 1;
        }

        /// <summary>
        /// Creates a new user account by inserting records into the Person
        /// and Logon tables within a database transaction.
        /// </summary>
        /// <param name="title">The user's title (optional).</param>
        /// <param name="firstName">The user's first name.</param>
        /// <param name="middleName">The user's middle name (optional).</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="suffix">The user's suffix (optional).</param>
        /// <param name="address">Primary address line.</param>
        /// <param name="address2">Secondary address line (optional).</param>
        /// <param name="address3">Tertiary address line (optional).</param>
        /// <param name="city">City of residence.</param>
        /// <param name="state">State of residence.</param>
        /// <param name="zip">ZIP code.</param>
        /// <param name="phonePrimary">Primary phone number (optional).</param>
        /// <param name="phoneSecondary">Secondary phone number (optional).</param>
        /// <param name="username">Desired username for login.</param>
        /// <param name="password">Password for the account.</param>
        /// <param name="positionID">The position ID associated with the user.</param>
        /// <param name="q1ID">First security question ID.</param>
        /// <param name="a1">Answer to the first security question.</param>
        /// <param name="q2ID">Second security question ID.</param>
        /// <param name="a2">Answer to the second security question.</param>
        /// <param name="q3ID">Third security question ID.</param>
        /// <param name="a3">Answer to the third security question.</param>
        /// <param name="email">Email address (optional).</param>
        /// <returns>
        /// True if the user account is successfully created; otherwise, false.
        /// </returns>
        public static bool CreateNewUser(
    string title, string firstName, string middleName, string lastName, string suffix,
    string address, string address2, string address3,
    string city, string state, string zip,
    string phonePrimary, string phoneSecondary,
    string username, string password,
    int positionID,
    int q1ID, string a1,
    int q2ID, string a2,
    int q3ID, string a3,
    string email)
        {
            if (IsUsernameTaken(username))
            {
                MessageBox.Show("Username already taken. Choose another.");
                return false;
            }

            if (q1ID == q2ID || q1ID == q3ID || q2ID == q3ID)
            {
                MessageBox.Show("Security questions must be unique.");
                return false;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(CONNECT_STRING))
                {
                    conn.Open();
                    using (SQLiteTransaction trans = conn.BeginTransaction())
                    {
                        string personInsert = @"
                    INSERT INTO Person
                    (Title, NameFirst, NameMiddle, NameLast, Suffix,
                     Address1, Address2, Address3, City, State, Zipcode,
                     PhonePrimary, PhoneSecondary, Email, PositionID)
                    VALUES
                    (@Title, @FirstName, @MiddleName, @LastName, @Suffix,
                     @Address, @Address2, @Address3, @City, @State, @Zip,
                     @PhonePrimary, @PhoneSecondary, @Email, @PositionID);

                    SELECT last_insert_rowid();";

                        using (SQLiteCommand cmdPerson = new SQLiteCommand(personInsert, conn, trans))
                        {
                            cmdPerson.Parameters.AddWithValue("@Title", string.IsNullOrWhiteSpace(title) ? DBNull.Value : (object)title);
                            cmdPerson.Parameters.AddWithValue("@FirstName", firstName);
                            cmdPerson.Parameters.AddWithValue("@MiddleName", string.IsNullOrWhiteSpace(middleName) ? DBNull.Value : (object)middleName);
                            cmdPerson.Parameters.AddWithValue("@LastName", lastName);
                            cmdPerson.Parameters.AddWithValue("@Suffix", string.IsNullOrWhiteSpace(suffix) ? DBNull.Value : (object)suffix);
                            cmdPerson.Parameters.AddWithValue("@Address", address);
                            cmdPerson.Parameters.AddWithValue("@Address2", string.IsNullOrWhiteSpace(address2) ? DBNull.Value : (object)address2);
                            cmdPerson.Parameters.AddWithValue("@Address3", string.IsNullOrWhiteSpace(address3) ? DBNull.Value : (object)address3);
                            cmdPerson.Parameters.AddWithValue("@City", city);
                            cmdPerson.Parameters.AddWithValue("@State", state);
                            cmdPerson.Parameters.AddWithValue("@Zip", zip);
                            cmdPerson.Parameters.AddWithValue("@PhonePrimary", string.IsNullOrWhiteSpace(phonePrimary) ? DBNull.Value : (object)phonePrimary);
                            cmdPerson.Parameters.AddWithValue("@PhoneSecondary", string.IsNullOrWhiteSpace(phoneSecondary) ? DBNull.Value : (object)phoneSecondary);
                            cmdPerson.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? DBNull.Value : (object)email);
                            cmdPerson.Parameters.AddWithValue("@PositionID", positionID);

                            int personID = Convert.ToInt32(cmdPerson.ExecuteScalar());

                            string logonInsert = @"
                        INSERT INTO Logon
                        (PersonID, LogonName, Password,
                         FirstChallengeQuestion, FirstChallengeAnswer,
                         SecondChallengeQuestion, SecondChallengeAnswer,
                         ThirdChallengeQuestion, ThirdChallengeAnswer,
                         PositionTitle)
                        VALUES
                        (@PersonID, @Username, @Password,
                         @Q1, @A1, @Q2, @A2, @Q3, @A3,
                         (SELECT PositionTitle FROM Position WHERE PositionID = @PositionID));";

                            using (SQLiteCommand cmdLogon = new SQLiteCommand(logonInsert, conn, trans))
                            {
                                cmdLogon.Parameters.AddWithValue("@PersonID", personID);
                                cmdLogon.Parameters.AddWithValue("@Username", username);
                                cmdLogon.Parameters.AddWithValue("@Password", password);
                                cmdLogon.Parameters.AddWithValue("@Q1", q1ID);
                                cmdLogon.Parameters.AddWithValue("@A1", a1.Trim());
                                cmdLogon.Parameters.AddWithValue("@Q2", q2ID);
                                cmdLogon.Parameters.AddWithValue("@A2", a2.Trim());
                                cmdLogon.Parameters.AddWithValue("@Q3", q3ID);
                                cmdLogon.Parameters.AddWithValue("@A3", a3.Trim());
                                cmdLogon.Parameters.AddWithValue("@PositionID", positionID);

                                cmdLogon.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Create account failed: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Updates the password for a specified user account.
        /// </summary>
        /// <param name="username">The username of the account.</param>
        /// <param name="newPassword">The new password to assign.</param>
        /// <returns>
        /// True if the password was successfully updated;
        /// otherwise, false.
        /// </returns>
        public static bool UpdatePassword(string username, string newPassword)
        {
            string sql = @"
        UPDATE Logon
        SET Password = @password
        WHERE LOWER(LogonName) = LOWER(@username);";

            int rowsAffected = ExecuteNonQuery(sql,
                new SQLiteParameter("@username", username),
                new SQLiteParameter("@password", newPassword)
            );

            return rowsAffected > 0;
        }


        /// <summary>
        /// Retrieves all active inventory items along with their category names.
        /// Excludes discontinued items.
        /// </summary>
        /// <returns>
        /// A DataTable containing inventory items and their associated categories.
        /// </returns>
        public static DataTable GetInventoryWithCategory()
        {
            string sql = @"
        SELECT I.InventoryID,
               I.ItemName,
               C.CategoryName,
               I.RetailPrice,
               I.Quantity
        FROM Inventory I
        INNER JOIN Categories C
            ON I.CategoryID = C.CategoryID
        WHERE I.Discontinued = 0;";

            return GetDataTable(sql);
        }

        /// <summary>
        /// Retrieves detailed information for a specific inventory item by its ID.
        /// </summary>
        /// <param name="inventoryID">The unique identifier of the inventory item.</param>
        /// <returns>
        /// A DataRow containing the product details if found; otherwise, null.
        /// </returns>
        public static DataRow GetProductDetailsByID(int inventoryID)
        {
            string sql = @"
        SELECT InventoryID,
               ItemName,
               ItemDescription,
               RetailPrice,
               Quantity,
               ItemImage,
               Discontinued
        FROM Inventory
        WHERE InventoryID = @InventoryID;";

            DataTable dt = GetDataTable(
                sql,
                new SQLiteParameter("@InventoryID", inventoryID)
            );

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Inserts a new order record into the database.
        /// </summary>
        /// <param name="order">The order object containing order details.</param>
        /// <returns>
        /// The newly created OrderID if successful; otherwise, -1.
        /// </returns>
        public static int InsertOrder(Order order)
        {
            string sql = @"
        INSERT INTO Orders
        (DiscountID, PersonID, EmployeeID, OrderDate, CC_Number, ExpDate, CCV)
        VALUES
        (@DiscountID, @PersonID, NULL, @OrderDate, @CC_Number, @ExpDate, @CCV);

        SELECT last_insert_rowid();";

            object result = ExecuteScalar(
                sql,
                new SQLiteParameter("@DiscountID",
                    order.DiscountID.HasValue ? (object)order.DiscountID.Value : DBNull.Value),
                new SQLiteParameter("@PersonID", order.PersonID),
                new SQLiteParameter("@OrderDate", order.OrderDate),
                new SQLiteParameter("@CC_Number", order.CC_Number),
                new SQLiteParameter("@ExpDate", order.ExpDate),
                new SQLiteParameter("@CCV", order.CCV)
            );

            return result == null ? -1 : Convert.ToInt32(result);
        }

        /// <summary>
        /// Inserts a new order detail record associated with an order.
        /// </summary>
        /// <param name="detail">The order detail containing item and quantity information.</param>
        public static void InsertOrderDetail(OrderDetail detail)
        {
            string sql = @"
        INSERT INTO OrderDetails
        (OrderID, InventoryID, DiscountID, Quantity)
        VALUES
        (@OrderID, @InventoryID, @DiscountID, @Quantity);";

            ExecuteNonQuery(sql,
                new SQLiteParameter("@OrderID", detail.OrderID),
                new SQLiteParameter("@InventoryID", detail.InventoryID),
                new SQLiteParameter("@DiscountID",
                    detail.DiscountID.HasValue
                        ? (object)detail.DiscountID.Value
                        : DBNull.Value),
                new SQLiteParameter("@Quantity", detail.Quantity)
            );
        }

        /// <summary>
        /// Updates the inventory quantity by subtracting the purchased amount.
        /// </summary>
        /// <param name="inventoryID">The ID of the inventory item.</param>
        /// <param name="quantityPurchased">The quantity to subtract from inventory.</param>
        public static void UpdateInventoryQuantity(int inventoryID, int quantityPurchased)
        {
            string sql = @"
        UPDATE Inventory
        SET Quantity = Quantity - @QuantityPurchased
        WHERE InventoryID = @InventoryID;";

            ExecuteNonQuery(sql,
                new SQLiteParameter("@InventoryID", inventoryID),
                new SQLiteParameter("@QuantityPurchased", quantityPurchased)
            );
        }

        /// <summary>
        /// Retrieves a valid discount based on a promotional code.
        /// Ensures the discount is currently active and not expired.
        /// </summary>
        /// <param name="promoCode">The promotional discount code.</param>
        /// <returns>
        /// A DataRow containing the discount information if valid; otherwise, null.
        /// </returns>
        public static DataRow GetDiscountByCode(string promoCode)
        {
            string sql = @"
        SELECT *
        FROM Discounts
        WHERE LOWER(DiscountCode) = LOWER(@PromoCode)
          AND (StartDate IS NULL OR StartDate <= date('now'))
          AND ExpirationDate >= date('now')
        LIMIT 1;";

            DataTable dt = GetDataTable(
                sql,
                new SQLiteParameter("@PromoCode", promoCode)
            );

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Searches inventory items based on a keyword and optional category filter.
        /// Can include or exclude discontinued items.
        /// </summary>
        /// <param name="keyword">
        /// A search term used to match item names or descriptions.
        /// Pass null or empty to return all items.
        /// </param>
        /// <param name="categoryID">
        /// Optional category ID to filter results.
        /// If null, all categories are included.
        /// </param>
        /// <param name="includeDiscontinued">
        /// Indicates whether discontinued items should be included in the results.
        /// </param>
        /// <returns>
        /// A DataTable containing inventory items that match the search criteria.
        /// </returns>
        public static DataTable SearchInventory(
    string keyword,
    int? categoryID = null,
    bool includeDiscontinued = false)
        {
            string sql = @"
        SELECT 
            I.InventoryID,
            I.ItemName,
            C.CategoryName,
            I.ItemDescription,
            I.RetailPrice,
            I.Cost,
            I.Quantity,
            I.RestockThreshold,
            I.Discontinued
        FROM Inventory I
        INNER JOIN Categories C
            ON I.CategoryID = C.CategoryID
        WHERE
            (@IncludeDiscontinued = 1 OR I.Discontinued = 0)
            AND (@Keyword IS NULL
                 OR I.ItemName LIKE @Keyword
                 OR I.ItemDescription LIKE @Keyword)";

            if (categoryID.HasValue)
                sql += " AND I.CategoryID = @CategoryID";

            List<SQLiteParameter> parameters = new List<SQLiteParameter>
    {
        new SQLiteParameter("@IncludeDiscontinued", includeDiscontinued ? 1 : 0)
    };

            if (string.IsNullOrWhiteSpace(keyword))
                parameters.Add(new SQLiteParameter("@Keyword", DBNull.Value));
            else
                parameters.Add(new SQLiteParameter("@Keyword", $"%{keyword}%"));

            if (categoryID.HasValue)
                parameters.Add(new SQLiteParameter("@CategoryID", categoryID.Value));

            return GetDataTable(sql, parameters.ToArray());
        }

        /// <summary>
        /// Retrieves the PersonID associated with a given username.
        /// </summary>
        /// <param name="username">The username used to look up the person.</param>
        /// <returns>
        /// The PersonID if found; otherwise, null.
        /// </returns>
        public static int? GetPersonIDByUsername(string username)
        {
            string sql = @"
        SELECT PersonID
        FROM Logon
        WHERE LOWER(LogonName) = LOWER(@username);";

            object result = ExecuteScalar(
                sql,
                new SQLiteParameter("@username", username)
            );

            return result == null || result == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(result);
        }

        /// <summary>
        /// Retrieves all product categories from the database.
        /// </summary>
        /// <returns>
        /// A DataTable containing category IDs and category names,
        /// ordered alphabetically.
        /// </returns>
        public static DataTable GetAllCategories()
        {
            string sql = @"
        SELECT CategoryID, CategoryName
        FROM Categories
        ORDER BY CategoryName;";

            return GetDataTable(sql);
        }

        /// <summary>
        /// Retrieves basic information for a specific person.
        /// </summary>
        /// <param name="personID">The unique identifier of the person.</param>
        /// <returns>
        /// A DataRow containing the person's first name, last name,
        /// and primary phone number if found; otherwise, null.
        /// </returns>
        public static DataRow GetPersonInfo(int personID)
        {
            string sql = @"
        SELECT NameFirst, NameLast, PhonePrimary
        FROM Person
        WHERE PersonID = @PersonID;";

            DataTable dt = GetDataTable(
                sql,
                new SQLiteParameter("@PersonID", personID)
            );

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Retrieves the current available quantity for a specific inventory item.
        /// </summary>
        /// <param name="inventoryID">The ID of the inventory item.</param>
        /// <returns>
        /// The quantity available. Returns 0 if the item is not found
        /// or the value is null.
        /// </returns>
        public static int GetAvailableInventoryQuantity(int inventoryID)
        {
            string sql = @"
        SELECT Quantity
        FROM Inventory
        WHERE InventoryID = @InventoryID;";

            object result = ExecuteScalar(
                sql,
                new SQLiteParameter("@InventoryID", inventoryID)
            );

            return result == null || result == DBNull.Value
                ? 0
                : Convert.ToInt32(result);
        }

        /// <summary>
        /// Adds a new inventory item to the database.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="description">The description of the item (optional).</param>
        /// <param name="categoryID">The category ID the item belongs to.</param>
        /// <param name="cost">The cost of the item.</param>
        /// <param name="price">The retail price of the item.</param>
        /// <param name="quantity">The initial quantity in stock.</param>
        /// <param name="restockThreshold">The minimum quantity before restocking is needed.</param>
        /// <param name="available">Indicates whether the item is available (not discontinued).</param>
        /// <param name="itemImage">Optional image data for the item.</param>
        /// <returns>
        /// True if the item was successfully added; otherwise, false.
        /// </returns>
        public static bool AddInventoryItem(
    string name,
    string description,
    int categoryID,
    decimal cost,
    decimal price,
    int quantity,
    int restockThreshold,
    bool available,
    byte[] itemImage)
        {
            string sql = @"
        INSERT INTO Inventory
            (ItemName, ItemDescription, CategoryID, Cost, RetailPrice, Quantity,
             RestockThreshold, Discontinued, ItemImage)
        VALUES
            (@Name, @Description, @CategoryID, @Cost, @Price, @Quantity,
             @Threshold, @Discontinued, @Image);";

            int rows = ExecuteNonQuery(sql,
                new SQLiteParameter("@Name", name),
                new SQLiteParameter("@Description",
                    string.IsNullOrWhiteSpace(description)
                        ? DBNull.Value
                        : (object)description),
                new SQLiteParameter("@CategoryID", categoryID),
                new SQLiteParameter("@Cost", cost),
                new SQLiteParameter("@Price", price),
                new SQLiteParameter("@Quantity", quantity),
                new SQLiteParameter("@Threshold", restockThreshold),
                new SQLiteParameter("@Discontinued", available ? 0 : 1),
                new SQLiteParameter("@Image",
                    itemImage == null ? DBNull.Value : (object)itemImage)
            );

            return rows > 0;
        }

        /// <summary>
        /// Updates an existing inventory item's details.
        /// </summary>
        /// <param name="id">The ID of the inventory item to update.</param>
        /// <param name="name">The updated name of the item.</param>
        /// <param name="description">The updated description (optional).</param>
        /// <param name="categoryID">The updated category ID.</param>
        /// <param name="cost">The updated cost.</param>
        /// <param name="price">The updated retail price.</param>
        /// <param name="quantity">The updated quantity in stock.</param>
        /// <param name="restockThreshold">The updated restock threshold.</param>
        /// <param name="available">Indicates whether the item is available.</param>
        /// <param name="itemImage">
        /// The updated image data. If null, the existing image is preserved.
        /// </param>
        /// <returns>
        /// True if the item was successfully updated; otherwise, false.
        /// </returns>
        public static bool UpdateInventoryItem(
        int id,
        string name,
        string description,
        int categoryID,
        decimal cost,
        decimal price,
        int quantity,
        int restockThreshold,
        bool available,
        byte[] itemImage)
            {
                string sql = @"
    UPDATE Inventory
    SET ItemName = @Name,
        ItemDescription = @Description,
        CategoryID = @CategoryID,
        Cost = @Cost,
        RetailPrice = @Price,
        Quantity = @Quantity,
        RestockThreshold = @Threshold,
        Discontinued = @Discontinued,
        ItemImage = COALESCE(@Image, ItemImage) -- keep old image if null
    WHERE InventoryID = @ID;";

            int rows = ExecuteNonQuery(sql,
                new SQLiteParameter("@ID", id),
                new SQLiteParameter("@Name", name),
                new SQLiteParameter("@Description",
                    string.IsNullOrWhiteSpace(description)
                        ? DBNull.Value
                        : (object)description),
                new SQLiteParameter("@CategoryID", categoryID),
                new SQLiteParameter("@Cost", cost),
                new SQLiteParameter("@Price", price),
                new SQLiteParameter("@Quantity", quantity),
                new SQLiteParameter("@Threshold", restockThreshold),
                new SQLiteParameter("@Discontinued", available ? 0 : 1),
                new SQLiteParameter("@Image",
                    itemImage == null ? DBNull.Value : (object)itemImage)
            );

            return rows > 0;
        }

        /// <summary>
        /// Retrieves all inventory items that are below their restock threshold.
        /// Only active (non-discontinued) items are included.
        /// </summary>
        /// <returns>
        /// A DataTable containing items that need restocking.
        /// </returns>
        public static DataTable GetItemsBelowRestockThreshold()
        {
            string sql = @"
        SELECT InventoryID, ItemName, Quantity, RestockThreshold
        FROM Inventory
        WHERE Quantity < RestockThreshold
          AND Discontinued = 0;";

            return GetDataTable(sql);
        }

        /// <summary>
        /// Retrieves full inventory details for a specific item by ID.
        /// </summary>
        /// <param name="inventoryID">The unique identifier of the inventory item.</param>
        /// <returns>
        /// A DataRow containing the inventory details if found; otherwise, null.
        /// </returns>
        public static DataRow GetInventoryByID(int inventoryID)
        {
            string sql = @"
        SELECT InventoryID, ItemName, ItemDescription, CategoryID,
               RetailPrice, Cost, Quantity, RestockThreshold,
               Discontinued, ItemImage
        FROM Inventory
        WHERE InventoryID = @ID;";

            DataTable dt = GetDataTable(
                sql,
                new SQLiteParameter("@ID", inventoryID)
            );

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Marks an inventory item as discontinued.
        /// </summary>
        /// <param name="inventoryID">The ID of the inventory item.</param>
        /// <returns>
        /// True if the item was successfully marked as discontinued;
        /// otherwise, false.
        /// </returns>
        public static bool DisableInventoryItem(int inventoryID)
        {
            string sql = @"
        UPDATE Inventory
        SET Discontinued = 1
        WHERE InventoryID = @ID;";

            return ExecuteNonQuery(
                sql,
                new SQLiteParameter("@ID", inventoryID)
            ) > 0;
        }

        /// <summary>
        /// Updates the inventory by increasing the quantity of an item.
        /// </summary>
        /// <param name="id">The ID of the inventory item.</param>
        /// <param name="amount">The amount to add to the current quantity.</param>
        /// <returns>
        /// True if the inventory was successfully updated; otherwise, false.
        /// </returns>
        public static bool RestockItem(int id, int amount)
        {
            string sql = @"
        UPDATE Inventory
        SET Quantity = Quantity + @Amount
        WHERE InventoryID = @ID;";

            return ExecuteNonQuery(
                sql,
                new SQLiteParameter("@ID", id),
                new SQLiteParameter("@Amount", amount)
            ) > 0;
        }

        /// <summary>
        /// Retrieves all manager accounts from the database.
        /// Optionally excludes a specific person (e.g., the logged-in manager).
        /// </summary>
        /// <param name="excludePersonID">
        /// Optional PersonID to exclude from the results.
        /// </param>
        /// <returns>
        /// A DataTable containing manager account information.
        /// </returns>
        public static DataTable GetAllManagers(int? excludePersonID = null)
        {
            string sql = @"
        SELECT 
            L.LogonID,
            P.PersonID,
            P.NameFirst,
            P.NameLast,
            L.LogonName,
            IFNULL(L.AccountDisabled, 0) AS AccountDisabled,
            P.Email,
            P.PhonePrimary,
            P.Address1,
            P.Address2,
            P.Address3,
            P.City,
            P.State,
            P.Zipcode
        FROM Logon L
        JOIN Person P ON L.PersonID = P.PersonID
        WHERE L.PositionTitle = 'Manager'
          AND (L.AccountDeleted = 0 OR L.AccountDeleted IS NULL)
          AND (P.PersonDeleted = 0 OR P.PersonDeleted IS NULL)";

            List<SQLiteParameter> parameters = new List<SQLiteParameter>();

            if (excludePersonID.HasValue)
            {
                sql += " AND P.PersonID <> @ExcludePersonID";
                parameters.Add(new SQLiteParameter("@ExcludePersonID", excludePersonID.Value));
            }

            return GetDataTable(sql, parameters.ToArray());
        }

        /// <summary>
        /// Retrieves detailed information for a specific manager by PersonID.
        /// </summary>
        /// <param name="personID">The unique identifier of the manager.</param>
        /// <returns>
        /// A DataTable containing manager details, including logon information.
        /// </returns>
        public static DataTable GetManagerByID(int personID)
        {
            string sql = @"
        SELECT 
            P.PersonID,
            P.NameFirst,
            P.NameLast,
            P.Email,
            P.PhonePrimary,
            P.Address1,
            P.Address2,
            P.Address3,
            P.City,
            P.State,
            P.Zipcode,
            P.PositionID,
            L.LogonID,
            L.LogonName,
            L.Password,        -- kept intentionally
            IFNULL(L.AccountDisabled, 0) AS AccountDisabled
        FROM Person P
        JOIN Logon L ON P.PersonID = L.PersonID
        WHERE P.PersonID = @PersonID;";

            return GetDataTable(
                sql,
                new SQLiteParameter("@PersonID", personID)
            );
        }

        /// <summary>
        /// Retrieves detailed information for a specific customer by PersonID.
        /// Excludes deleted accounts.
        /// </summary>
        /// <param name="personID">The unique identifier of the customer.</param>
        /// <returns>
        /// A DataTable containing customer details if found; otherwise empty.
        /// </returns>
        public static DataTable GetCustomerByID(int personID)
        {
            string sql = @"
        SELECT 
            P.PersonID,
            P.NameFirst,
            P.NameLast,
            P.Email,
            P.PhonePrimary,
            P.Address1,
            P.Address2,
            P.Address3,
            P.City,
            P.State,
            P.Zipcode,
            P.PositionID,
            L.LogonID,
            L.LogonName,
            L.Password,
            IFNULL(L.AccountDisabled, 0) AS AccountDisabled
        FROM Person P
        JOIN Logon L ON P.PersonID = L.PersonID
        WHERE P.PersonID = @PersonID
          AND (P.PersonDeleted = 0 OR P.PersonDeleted IS NULL)
          AND (L.AccountDeleted = 0 OR L.AccountDeleted IS NULL);";

            return GetDataTable(
                sql,
                new SQLiteParameter("@PersonID", personID)
            );
        }

        /// <summary>
        /// Retrieves all active customer accounts from the database.
        /// Excludes deleted accounts.
        /// </summary>
        /// <returns>
        /// A DataTable containing customer account information.
        /// </returns>
        public static DataTable GetAllCustomers()
        {
            string sql = @"
        SELECT 
            L.LogonID,
            P.PersonID,
            P.NameFirst,
            P.NameLast,
            P.Email,
            P.PhonePrimary,
            L.LogonName,
            IFNULL(L.AccountDisabled, 0) AS AccountDisabled
        FROM Logon L
        JOIN Person P ON L.PersonID = P.PersonID
        WHERE L.PositionTitle = 'Customer'
          AND (L.AccountDeleted = 0 OR L.AccountDeleted IS NULL)
          AND (P.PersonDeleted = 0 OR P.PersonDeleted IS NULL);";

            return GetDataTable(sql);
        }

        /// <summary>
        /// Searches for customers based on a keyword.
        /// Matches against name, phone number, email, or PersonID.
        /// </summary>
        /// <param name="keyword">The search keyword.</param>
        /// <returns>
        /// A DataTable containing customers that match the search criteria.
        /// </returns>
        // POS methods
        public static DataTable SearchCustomers(string keyword)
        {
            string sql = @"
        SELECT 
            PersonID,
            NameFirst || ' ' || NameLast AS FullName,
            PhonePrimary,
            Email
        FROM Person
        WHERE (
                (NameFirst || ' ' || NameLast) LIKE @k
             OR PhonePrimary LIKE @k
             OR Email LIKE @k
             OR CAST(PersonID AS TEXT) LIKE @k
        )
        AND (PersonDeleted IS NULL OR PersonDeleted = 0);";

            return GetDataTable(
                sql,
                new SQLiteParameter("@k", "%" + keyword + "%")
            );
        }

        /// <summary>
        /// Enables or disables a user account.
        /// </summary>
        /// <param name="logonID">The LogonID of the account.</param>
        /// <param name="disable">
        /// True to disable the account; false to enable it.
        /// </param>
        /// <returns>
        /// True if the operation was successful; otherwise, false.
        /// </returns>
        public static bool DisableAccount(int logonID, bool disable)
        {
            string sql = $@"
        UPDATE Logon
        SET AccountDisabled = @Disabled
        WHERE LogonID = @LogonID";

            return ExecuteNonQuery(sql,
                new SQLiteParameter("@LogonID", logonID),
                new SQLiteParameter("@Disabled", disable)) > 0;
        }

        /// <summary>
        /// Soft-deletes a user account by marking both Person and Logon records as deleted.
        /// </summary>
        /// <param name="personID">The PersonID of the user.</param>
        /// <param name="logonID">The LogonID of the user.</param>
        /// <returns>
        /// True if the account was successfully marked as deleted; otherwise, false.
        /// </returns>
        public static bool DeleteAccount(int personID, int logonID)
        {
            string sql1 = $@"
        UPDATE Person
        SET PersonDeleted = 1
        WHERE PersonID = @PersonID";

            ExecuteNonQuery(sql1, new SQLiteParameter("@PersonID", personID));

            string sql2 = $@"
        UPDATE Logon
        SET AccountDeleted = 1
        WHERE LogonID = @LogonID";

            return ExecuteNonQuery(sql2, new SQLiteParameter("@LogonID", logonID)) > 0;
        }

        /// <summary>
        /// Updates both Person and Logon records for a user account.
        /// This operation is performed within a transaction to ensure data consistency.
        /// </summary>
        /// <param name="personID">The PersonID of the user.</param>
        /// <param name="logonID">The LogonID of the user.</param>
        /// <param name="first">The updated first name.</param>
        /// <param name="last">The updated last name.</param>
        /// <param name="email">The updated email (optional).</param>
        /// <param name="phone">The updated primary phone (optional).</param>
        /// <param name="address1">Primary address line.</param>
        /// <param name="address2">Secondary address line (optional).</param>
        /// <param name="address3">Tertiary address line (optional).</param>
        /// <param name="city">City of residence.</param>
        /// <param name="state">State of residence.</param>
        /// <param name="zip">ZIP code.</param>
        /// <param name="username">Updated username.</param>
        /// <param name="password">Updated password.</param>
        /// <param name="disabled">Indicates whether the account is disabled.</param>
        /// <param name="positionID">The position ID of the user.</param>
        /// <param name="positionTitle">The position title of the user.</param>
        /// <returns>
        /// True if the update was successful; otherwise, false.
        /// </returns>
        public static bool UpdateAccount(
    int personID,
    int logonID,
    string first,
    string last,
    string email,
    string phone,
    string address1,
    string address2,
    string address3,
    string city,
    string state,
    string zip,
    string username,
    string password,
    bool disabled,
    int positionID,
    string positionTitle)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(CONNECT_STRING))
                {
                    conn.Open();
                    using (SQLiteTransaction trans = conn.BeginTransaction())
                    {
                        string sqlPerson = @"
                    UPDATE Person
                    SET NameFirst = @First,
                        NameLast = @Last,
                        Email = @Email,
                        PhonePrimary = @Phone,
                        Address1 = @Address1,
                        Address2 = @Address2,
                        Address3 = @Address3,
                        City = @City,
                        State = @State,
                        Zipcode = @Zip,
                        PositionID = @PositionID
                    WHERE PersonID = @PersonID";

                        using (SQLiteCommand cmdPerson = new SQLiteCommand(sqlPerson, conn, trans))
                        {
                            cmdPerson.Parameters.AddWithValue("@First", first);
                            cmdPerson.Parameters.AddWithValue("@Last", last);
                            cmdPerson.Parameters.AddWithValue("@Email",
                                string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                            cmdPerson.Parameters.AddWithValue("@Phone",
                                string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
                            cmdPerson.Parameters.AddWithValue("@Address1", address1);
                            cmdPerson.Parameters.AddWithValue("@Address2",
                                string.IsNullOrWhiteSpace(address2) ? (object)DBNull.Value : address2);
                            cmdPerson.Parameters.AddWithValue("@Address3",
                                string.IsNullOrWhiteSpace(address3) ? (object)DBNull.Value : address3);
                            cmdPerson.Parameters.AddWithValue("@City", city);
                            cmdPerson.Parameters.AddWithValue("@State", state);
                            cmdPerson.Parameters.AddWithValue("@Zip", zip);
                            cmdPerson.Parameters.AddWithValue("@PositionID", positionID);
                            cmdPerson.Parameters.AddWithValue("@PersonID", personID);
                            cmdPerson.ExecuteNonQuery();
                        }

                        string sqlLogon = @"
                    UPDATE Logon
                    SET LogonName = @Username,
                        Password = @Password,
                        PositionTitle = @PositionTitle,
                        AccountDisabled = @Disabled
                    WHERE LogonID = @LogonID";

                        using (SQLiteCommand cmdLogon = new SQLiteCommand(sqlLogon, conn, trans))
                        {
                            cmdLogon.Parameters.AddWithValue("@Username", username);
                            cmdLogon.Parameters.AddWithValue("@Password", password);
                            cmdLogon.Parameters.AddWithValue("@PositionTitle", positionTitle);
                            cmdLogon.Parameters.AddWithValue("@Disabled", disabled ? 1 : 0);
                            cmdLogon.Parameters.AddWithValue("@LogonID", logonID);
                            cmdLogon.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Creates a new manager account by inserting records into the Person
        /// and Logon tables.
        /// </summary>
        /// <param name="first">First name of the manager.</param>
        /// <param name="last">Last name of the manager.</param>
        /// <param name="email">Email address (optional).</param>
        /// <param name="phone">Primary phone number (optional).</param>
        /// <param name="address1">Primary address line.</param>
        /// <param name="address2">Secondary address line (optional).</param>
        /// <param name="address3">Tertiary address line (optional).</param>
        /// <param name="city">City of residence.</param>
        /// <param name="state">State of residence.</param>
        /// <param name="zip">ZIP code.</param>
        /// <param name="username">Login username.</param>
        /// <param name="password">Login password.</param>
        /// <param name="q1ID">First security question ID.</param>
        /// <param name="a1">Answer to the first security question.</param>
        /// <param name="q2ID">Second security question ID.</param>
        /// <param name="a2">Answer to the second security question.</param>
        /// <param name="q3ID">Third security question ID.</param>
        /// <param name="a3">Answer to the third security question.</param>
        /// <returns>
        /// True if the manager account was successfully created; otherwise, false.
        /// </returns>
        public static bool AddManager(
    string first,
    string last,
    string email,
    string phone,
    string address1,
    string address2,
    string address3,
    string city,
    string state,
    string zip,
    string username,
    string password,
    int q1ID, string a1,
    int q2ID, string a2,
    int q3ID, string a3)
        {
            if (IsUsernameTaken(username))
                return false;

            string sqlPerson = @"
        INSERT INTO Person
            (NameFirst, NameLast, Email, PhonePrimary,
             Address1, Address2, Address3, City, State, Zipcode,
             PositionID, PersonDeleted)
        VALUES
            (@First, @Last, @Email, @Phone,
             @Address1, @Address2, @Address3, @City, @State, @Zip,
             1001, 0);

        SELECT last_insert_rowid();";

            object result = ExecuteScalar(sqlPerson,
                new SQLiteParameter("@First", first),
                new SQLiteParameter("@Last", last),
                new SQLiteParameter("@Email",
                    string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email),
                new SQLiteParameter("@Phone",
                    string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone),
                new SQLiteParameter("@Address1", address1),
                new SQLiteParameter("@Address2",
                    string.IsNullOrWhiteSpace(address2) ? (object)DBNull.Value : address2),
                new SQLiteParameter("@Address3",
                    string.IsNullOrWhiteSpace(address3) ? (object)DBNull.Value : address3),
                new SQLiteParameter("@City", city),
                new SQLiteParameter("@State", state),
                new SQLiteParameter("@Zip", zip)
            );

            if (result == null || !int.TryParse(result.ToString(), out int personID))
                return false;

            string sqlLogon = @"
        INSERT INTO Logon
            (PersonID, LogonName, Password,
             FirstChallengeQuestion, FirstChallengeAnswer,
             SecondChallengeQuestion, SecondChallengeAnswer,
             ThirdChallengeQuestion, ThirdChallengeAnswer,
             PositionTitle, AccountDisabled, AccountDeleted)
        VALUES
            (@PersonID, @Username, @Password,
             @Q1, @A1, @Q2, @A2, @Q3, @A3,
             'Manager', 0, 0);";

            return ExecuteNonQuery(sqlLogon,
                new SQLiteParameter("@PersonID", personID),
                new SQLiteParameter("@Username", username),
                new SQLiteParameter("@Password", password),
                new SQLiteParameter("@Q1", q1ID),
                new SQLiteParameter("@A1", a1),
                new SQLiteParameter("@Q2", q2ID),
                new SQLiteParameter("@A2", a2),
                new SQLiteParameter("@Q3", q3ID),
                new SQLiteParameter("@A3", a3)
            ) > 0;
        }

        /// <summary>
        /// Creates a new customer account by inserting records into the Person
        /// and Logon tables.
        /// </summary>
        /// <param name="first">First name of the customer.</param>
        /// <param name="last">Last name of the customer.</param>
        /// <param name="email">Email address (optional).</param>
        /// <param name="phone">Primary phone number (optional).</param>
        /// <param name="address1">Primary address line.</param>
        /// <param name="address2">Secondary address line (optional).</param>
        /// <param name="address3">Tertiary address line (optional).</param>
        /// <param name="city">City of residence.</param>
        /// <param name="state">State of residence.</param>
        /// <param name="zip">ZIP code.</param>
        /// <param name="username">Login username.</param>
        /// <param name="password">Login password.</param>
        /// <param name="q1">First security question ID.</param>
        /// <param name="a1">Answer to the first security question.</param>
        /// <param name="q2">Second security question ID.</param>
        /// <param name="a2">Answer to the second security question.</param>
        /// <param name="q3">Third security question ID.</param>
        /// <param name="a3">Answer to the third security question.</param>
        /// <returns>
        /// True if the customer account was successfully created; otherwise, false.
        /// </returns>
        public static bool AddCustomer(
    string first,
    string last,
    string email,
    string phone,
    string address1,
    string address2,
    string address3,
    string city,
    string state,
    string zip,
    string username,
    string password,
    int q1, string a1,
    int q2, string a2,
    int q3, string a3)
        {
            // Check if username already exists
            if (IsUsernameTaken(username))
                return false;

            // ---------- INSERT PERSON ----------
            string sqlPerson = @"
        INSERT INTO Person
            (NameFirst, NameLast, Email, PhonePrimary,
             Address1, Address2, Address3, City, State, Zipcode,
             PositionID, PersonDeleted)
        VALUES
            (@First, @Last, @Email, @Phone,
             @Address1, @Address2, @Address3, @City, @State, @Zip,
             1000, 0);

        SELECT last_insert_rowid();";

            object result = ExecuteScalar(
                sqlPerson,
                new SQLiteParameter("@First", first),
                new SQLiteParameter("@Last", last),
                new SQLiteParameter("@Email",
                    string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email),
                new SQLiteParameter("@Phone",
                    string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone),
                new SQLiteParameter("@Address1", address1),
                new SQLiteParameter("@Address2",
                    string.IsNullOrWhiteSpace(address2) ? (object)DBNull.Value : address2),
                new SQLiteParameter("@Address3",
                    string.IsNullOrWhiteSpace(address3) ? (object)DBNull.Value : address3),
                new SQLiteParameter("@City", city),
                new SQLiteParameter("@State", state),
                new SQLiteParameter("@Zip", zip)
            );

            if (result == null || !int.TryParse(result.ToString(), out int personID))
                return false;

            // ---------- INSERT LOGON ----------
            string sqlLogon = @"
        INSERT INTO Logon
            (PersonID, LogonName, Password,
             FirstChallengeQuestion, FirstChallengeAnswer,
             SecondChallengeQuestion, SecondChallengeAnswer,
             ThirdChallengeQuestion, ThirdChallengeAnswer,
             PositionTitle, AccountDisabled, AccountDeleted)
        VALUES
            (@PersonID, @Username, @Password,
             @Q1, @A1,
             @Q2, @A2,
             @Q3, @A3,
             'Customer', 0, 0);";

            int rows = ExecuteNonQuery(
                sqlLogon,
                new SQLiteParameter("@PersonID", personID),
                new SQLiteParameter("@Username", username),
                new SQLiteParameter("@Password", password),
                new SQLiteParameter("@Q1", q1),
                new SQLiteParameter("@A1", a1),
                new SQLiteParameter("@Q2", q2),
                new SQLiteParameter("@A2", a2),
                new SQLiteParameter("@Q3", q3),
                new SQLiteParameter("@A3", a3)
            );

            return rows > 0;
        }

        /// <summary>
        /// Retrieves all active employee accounts from the database.
        /// Excludes deleted accounts.
        /// </summary>
        /// <returns>
        /// A DataTable containing employee account information.
        /// </returns>
        public static DataTable GetAllEmployees()
        {
            string sql = @"
        SELECT 
            L.LogonID,
            P.PersonID,
            P.NameFirst,
            P.NameLast,
            P.Email,
            P.PhonePrimary,
            L.LogonName,
            IFNULL(L.AccountDisabled, 0) AS AccountDisabled
        FROM Logon L
        JOIN Person P ON L.PersonID = P.PersonID
        WHERE L.PositionTitle = 'Employee'
          AND (L.AccountDeleted = 0 OR L.AccountDeleted IS NULL)
          AND (P.PersonDeleted = 0 OR P.PersonDeleted IS NULL);";

            return GetDataTable(sql);
        }

        /// <summary>
        /// Retrieves detailed information for a specific employee by PersonID.
        /// </summary>
        /// <param name="personID">The unique identifier of the employee.</param>
        /// <returns>
        /// A DataTable containing employee details if found; otherwise empty.
        /// </returns>
        public static DataTable GetEmployeeByID(int personID)
        {
            string sql = @"
        SELECT 
            P.PersonID,
            P.NameFirst,
            P.NameLast,
            P.Email,
            P.PhonePrimary,
            P.Address1,
            P.Address2,
            P.Address3,
            P.City,
            P.State,
            P.Zipcode,
            P.PositionID,
            L.LogonID,
            L.LogonName,
            L.Password,
            IFNULL(L.AccountDisabled, 0) AS AccountDisabled
        FROM Person P
        JOIN Logon L ON P.PersonID = L.PersonID
        WHERE P.PersonID = @PersonID
          AND L.PositionTitle = 'Employee'
          AND (P.PersonDeleted = 0 OR P.PersonDeleted IS NULL)
          AND (L.AccountDeleted = 0 OR L.AccountDeleted IS NULL);";

            return GetDataTable(
                sql,
                new SQLiteParameter("@PersonID", personID)
            );
        }

        /// <summary>
        /// Creates a new employee account by inserting records into the Person
        /// and Logon tables.
        /// </summary>
        /// <param name="first">First name of the employee.</param>
        /// <param name="last">Last name of the employee.</param>
        /// <param name="email">Email address (optional).</param>
        /// <param name="phone">Primary phone number (optional).</param>
        /// <param name="address1">Primary address line.</param>
        /// <param name="address2">Secondary address line (optional).</param>
        /// <param name="address3">Tertiary address line (optional).</param>
        /// <param name="city">City of residence.</param>
        /// <param name="state">State of residence.</param>
        /// <param name="zip">ZIP code.</param>
        /// <param name="username">Login username.</param>
        /// <param name="password">Login password.</param>
        /// <param name="q1ID">First security question ID.</param>
        /// <param name="a1">Answer to the first security question.</param>
        /// <param name="q2ID">Second security question ID.</param>
        /// <param name="a2">Answer to the second security question.</param>
        /// <param name="q3ID">Third security question ID.</param>
        /// <param name="a3">Answer to the third security question.</param>
        /// <returns>
        /// True if the employee account was successfully created; otherwise, false.
        /// </returns>
        public static bool AddEmployee(
    string first,
    string last,
    string email,
    string phone,
    string address1,
    string address2,
    string address3,
    string city,
    string state,
    string zip,
    string username,
    string password,
    int q1ID, string a1,
    int q2ID, string a2,
    int q3ID, string a3)
        {
            // Check if username already exists
            if (IsUsernameTaken(username))
                return false;

            // ---------- INSERT PERSON ----------
            string sqlPerson = @"
        INSERT INTO Person
            (NameFirst, NameLast, Email, PhonePrimary,
             Address1, Address2, Address3, City, State, Zipcode,
             PositionID, PersonDeleted)
        VALUES
            (@First, @Last, @Email, @Phone,
             @Address1, @Address2, @Address3, @City, @State, @Zip,
             1002, 0);

        SELECT last_insert_rowid();";

            object result = ExecuteScalar(
                sqlPerson,
                new SQLiteParameter("@First", first),
                new SQLiteParameter("@Last", last),
                new SQLiteParameter("@Email",
                    string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email),
                new SQLiteParameter("@Phone",
                    string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone),
                new SQLiteParameter("@Address1", address1),
                new SQLiteParameter("@Address2",
                    string.IsNullOrWhiteSpace(address2) ? (object)DBNull.Value : address2),
                new SQLiteParameter("@Address3",
                    string.IsNullOrWhiteSpace(address3) ? (object)DBNull.Value : address3),
                new SQLiteParameter("@City", city),
                new SQLiteParameter("@State", state),
                new SQLiteParameter("@Zip", zip)
            );

            if (result == null || !int.TryParse(result.ToString(), out int personID))
                return false;

            // ---------- INSERT LOGON ----------
            string sqlLogon = @"
        INSERT INTO Logon
            (PersonID, LogonName, Password,
             FirstChallengeQuestion, FirstChallengeAnswer,
             SecondChallengeQuestion, SecondChallengeAnswer,
             ThirdChallengeQuestion, ThirdChallengeAnswer,
             PositionTitle, AccountDisabled, AccountDeleted)
        VALUES
            (@PersonID, @Username, @Password,
             @Q1, @A1,
             @Q2, @A2,
             @Q3, @A3,
             'Employee', 0, 0);";

            int rows = ExecuteNonQuery(
                sqlLogon,
                new SQLiteParameter("@PersonID", personID),
                new SQLiteParameter("@Username", username),
                new SQLiteParameter("@Password", password),
                new SQLiteParameter("@Q1", q1ID),
                new SQLiteParameter("@A1", a1),
                new SQLiteParameter("@Q2", q2ID),
                new SQLiteParameter("@A2", a2),
                new SQLiteParameter("@Q3", q3ID),
                new SQLiteParameter("@A3", a3)
            );

            return rows > 0;
        }

        /// <summary>
        /// Searches for employees based on a keyword.
        /// Matches against full name, phone number, email, or PersonID.
        /// </summary>
        /// <param name="keyword">The search keyword.</param>
        /// <returns>
        /// A DataTable containing employees that match the search criteria.
        /// </returns>
        public static DataTable SearchEmployees(string keyword)
        {
            string sql = @"
        SELECT 
            P.PersonID,
            P.NameFirst || ' ' || P.NameLast AS FullName,
            P.PhonePrimary,
            P.Email
        FROM Person P
        JOIN Logon L ON P.PersonID = L.PersonID
        WHERE L.PositionTitle = 'Employee'
          AND (
                P.NameFirst || ' ' || P.NameLast LIKE @k
                OR P.PhonePrimary LIKE @k
                OR P.Email LIKE @k
                OR P.PersonID LIKE @k
              )
          AND (P.PersonDeleted IS NULL OR P.PersonDeleted = 0)
          AND (L.AccountDeleted IS NULL OR L.AccountDeleted = 0);";

            return GetDataTable(
                sql,
                new SQLiteParameter("@k", "%" + keyword + "%")
            );
        }

        /// <summary>
        /// Retrieves all active (non-deleted) discounts, including associated item names.
        /// </summary>
        /// <returns>
        /// A DataTable containing discount information.
        /// </returns>
        public static DataTable GetAllDiscounts()
        {
            string sql = @"
        SELECT d.DiscountID, d.DiscountCode, d.Description,
               d.DiscountLevel, d.InventoryID,
               d.DiscountType, d.DiscountPercentage, d.DiscountDollarAmount,
               d.StartDate, d.ExpirationDate,
               i.ItemName
        FROM Discounts d
        LEFT JOIN Inventory i ON d.InventoryID = i.InventoryID
        WHERE d.DiscountDeleted IS NULL OR d.DiscountDeleted = 0
        ORDER BY d.DiscountCode";

            return GetDataTable(sql);
        }

        /// <summary>
        /// Retrieves active discounts for a specific inventory item.
        /// Prioritizes item-level discounts; if none exist, returns cart-level discounts.
        /// </summary>
        /// <param name="inventoryID">The inventory item ID.</param>
        /// <returns>
        /// A DataTable containing applicable discounts.
        /// </returns>
        public static DataTable GetActiveDiscountsSmart(int inventoryID)
        {
            // Item-level discounts
            string sqlItem = $@"
        SELECT d.DiscountID, d.DiscountCode, d.Description,
               d.DiscountLevel, d.InventoryID,
               d.DiscountType, d.DiscountPercentage, d.DiscountDollarAmount,
               d.StartDate, d.ExpirationDate
        FROM Discounts d
        WHERE d.DiscountLevel = 1
          AND d.InventoryID = {inventoryID}
          AND d.ExpirationDate >= DATE('now')
          AND (d.DiscountDeleted IS NULL OR d.DiscountDeleted = 0)
        ORDER BY d.DiscountCode";

            DataTable dtItem = GetDataTable(sqlItem);

            if (dtItem.Rows.Count > 0)
                return dtItem;

            // Cart-level discounts
            string sqlCart = @"
        SELECT d.DiscountID, d.DiscountCode, d.Description,
               d.DiscountLevel, d.InventoryID,
               d.DiscountType, d.DiscountPercentage, d.DiscountDollarAmount,
               d.StartDate, d.ExpirationDate
        FROM Discounts d
        WHERE d.DiscountLevel = 0
          AND d.ExpirationDate >= DATE('now')
          AND (d.DiscountDeleted IS NULL OR d.DiscountDeleted = 0)
        ORDER BY d.DiscountCode";

            return GetDataTable(sqlCart);
        }

        /// <summary>
        /// Adds a new discount to the database.
        /// </summary>
        /// <param name="code">The discount code.</param>
        /// <param name="description">Description of the discount.</param>
        /// <param name="level">Discount level (0 = cart-level, 1 = item-level).</param>
        /// <param name="inventoryID">Associated inventory item (if item-level).</param>
        /// <param name="type">Discount type (0 = percentage, 1 = fixed amount).</param>
        /// <param name="percent">Percentage discount value (optional).</param>
        /// <param name="dollar">Fixed dollar discount value (optional).</param>
        /// <param name="start">Start date (optional).</param>
        /// <param name="expiration">Expiration date.</param>
        /// <returns>
        /// The ID of the newly created discount.
        /// </returns>
        public static int AddDiscount(
    string code, string description, int level, int? inventoryID,
    int type, decimal? percent, decimal? dollar,
    DateTime? start, DateTime expiration)
        {
            string sql = @"
        INSERT INTO Discounts
            (DiscountCode, Description, DiscountLevel, InventoryID,
             DiscountType, DiscountPercentage, DiscountDollarAmount,
             StartDate, ExpirationDate)
        VALUES
            (@Code, @Description, @Level, @InventoryID,
             @Type, @Percent, @Dollar,
             @Start, @End);";

            ExecuteNonQuery(sql,
                new SQLiteParameter("@Code", code),
                new SQLiteParameter("@Description", description),
                new SQLiteParameter("@Level", level),
                new SQLiteParameter("@InventoryID", (object)inventoryID ?? DBNull.Value),
                new SQLiteParameter("@Type", type),
                new SQLiteParameter("@Percent", (object)percent ?? DBNull.Value),
                new SQLiteParameter("@Dollar", (object)dollar ?? DBNull.Value),
                new SQLiteParameter("@Start", (object)start?.ToString("yyyy-MM-dd") ?? DBNull.Value),
                new SQLiteParameter("@End", expiration.ToString("yyyy-MM-dd"))
            );

            // Get last inserted row id in SQLite
            string sqlLastID = "SELECT last_insert_rowid();";
            object result = ExecuteScalar(sqlLastID);
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Updates an existing discount.
        /// </summary>
        /// <param name="id">The discount ID.</param>
        /// <param name="code">The discount code.</param>
        /// <param name="description">Description of the discount.</param>
        /// <param name="level">Discount level (0 = cart-level, 1 = item-level).</param>
        /// <param name="inventoryID">Associated inventory item (if applicable).</param>
        /// <param name="type">Discount type (0 = percentage, 1 = fixed amount).</param>
        /// <param name="percent">Percentage discount value (optional).</param>
        /// <param name="dollar">Fixed dollar discount value (optional).</param>
        /// <param name="start">Start date (optional).</param>
        /// <param name="expiration">Expiration date.</param>
        /// <returns>
        /// True if the update was successful; otherwise, false.
        /// </returns>
        public static bool UpdateDiscount(
    int id, string code, string description, int level, int? inventoryID,
    int type, decimal? percent, decimal? dollar,
    DateTime? start, DateTime expiration)
        {
            string sql = @"
        UPDATE Discounts
        SET DiscountCode = @Code,
            Description = @Description,
            DiscountLevel = @Level,
            InventoryID = @InventoryID,
            DiscountType = @Type,
            DiscountPercentage = @Percent,
            DiscountDollarAmount = @Dollar,
            StartDate = @Start,
            ExpirationDate = @End
        WHERE DiscountID = @ID";

            int rows = ExecuteNonQuery(sql,
                new SQLiteParameter("@ID", id),
                new SQLiteParameter("@Code", code),
                new SQLiteParameter("@Description", description),
                new SQLiteParameter("@Level", level),
                new SQLiteParameter("@InventoryID", (object)inventoryID ?? DBNull.Value),
                new SQLiteParameter("@Type", type),
                new SQLiteParameter("@Percent", (object)percent ?? DBNull.Value),
                new SQLiteParameter("@Dollar", (object)dollar ?? DBNull.Value),
                new SQLiteParameter("@Start", (object)start?.ToString("yyyy-MM-dd") ?? DBNull.Value),
                new SQLiteParameter("@End", expiration.ToString("yyyy-MM-dd"))
            );

            return rows > 0;
        }

        /// <summary>
        /// Soft-deletes a discount by marking it as deleted.
        /// </summary>
        /// <param name="discountID">The discount ID.</param>
        /// <returns>
        /// True if the discount was successfully deleted; otherwise, false.
        /// </returns>
        public static bool DeleteDiscount(int discountID)
        {
            string sql = @"
        UPDATE Discounts
        SET DiscountDeleted = 1
        WHERE DiscountID = @DiscountID";

            var param = new SQLiteParameter("@DiscountID", discountID);
            return ExecuteNonQuery(sql, param) > 0;
        }

        /// <summary>
        /// Retrieves a specific discount by ID, including associated item name.
        /// </summary>
        /// <param name="discountID">The discount ID.</param>
        /// <returns>
        /// A DataRow containing discount details if found; otherwise null.
        /// </returns>
        public static DataRow GetDiscountByID(int discountID)
        {
            string sql = @"
        SELECT d.DiscountID, d.DiscountCode, d.Description,
               d.DiscountLevel, d.InventoryID,
               d.DiscountType, d.DiscountPercentage, d.DiscountDollarAmount,
               d.StartDate, d.ExpirationDate,
               i.ItemName
        FROM Discounts d
        LEFT JOIN Inventory i ON d.InventoryID = i.InventoryID
        WHERE d.DiscountID = @ID
          AND (d.DiscountDeleted IS NULL OR d.DiscountDeleted = 0)";

            var param = new SQLiteParameter("@ID", discountID);

            DataTable dt = GetDataTable(sql, param);

            return (dt != null && dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Searches for discounts based on a keyword.
        /// Matches against discount code, description, or item name.
        /// </summary>
        /// <param name="keyword">The search keyword.</param>
        /// <returns>
        /// A DataTable containing matching discounts.
        /// </returns>
        public static DataTable SearchDiscounts(string keyword)
        {
            string sql = @"
        SELECT d.DiscountID, d.DiscountCode, d.Description,
               d.DiscountLevel, d.InventoryID,
               d.DiscountType, d.DiscountPercentage, d.DiscountDollarAmount,
               d.StartDate, d.ExpirationDate,
               i.ItemName
        FROM Discounts d
        LEFT JOIN Inventory i ON d.InventoryID = i.InventoryID
        WHERE (d.DiscountDeleted IS NULL OR d.DiscountDeleted = 0)
          AND (d.DiscountCode LIKE @Search
               OR d.Description LIKE @Search
               OR i.ItemName LIKE @Search)
        ORDER BY d.DiscountCode;";

            var p = new SQLiteParameter("@Search", "%" + keyword + "%");
            return GetDataTable(sql, p);
        }


        /// <summary>
        /// Generates a sales report for a given date range.
        /// Calculates totals including item-level and cart-level discounts,
        /// and applies tax to produce the final sale amount.
        /// </summary>
        /// <param name="startDate">Start date of the report.</param>
        /// <param name="endDate">End date of the report.</param>
        /// <returns>
        /// A DataTable containing order IDs, dates, and total sales amounts.
        /// </returns>
        public static DataTable GetSalesReport(DateTime startDate, DateTime endDate)
        {
            string sql = @"
WITH ItemLines AS (
    SELECT 
        O.OrderID,
        O.OrderDate,
        OD.Quantity,
        I.RetailPrice,
        OD.InventoryID,
        OD.DiscountID AS ItemDiscountID
    FROM Orders O
    JOIN OrderDetails OD ON O.OrderID = OD.OrderID
    JOIN Inventory I ON OD.InventoryID = I.InventoryID
    WHERE O.OrderDate BETWEEN @StartDate AND @EndDate
),
ItemDiscountCalc AS (
    SELECT 
        IL.OrderID,
        IL.OrderDate,
        CASE 
            WHEN D.DiscountLevel = 1 
                 AND D.InventoryID = IL.InventoryID
                 AND D.DiscountType = 0 THEN 
                     (IL.Quantity * IL.RetailPrice) * (1 - D.DiscountPercentage)

            WHEN D.DiscountLevel = 1
                 AND D.InventoryID = IL.InventoryID
                 AND D.DiscountType = 1 THEN 
                     (IL.Quantity * IL.RetailPrice) - D.DiscountDollarAmount

            ELSE (IL.Quantity * IL.RetailPrice)
        END AS DiscountedLineTotal
    FROM ItemLines IL
    LEFT JOIN Discounts D 
           ON IL.ItemDiscountID = D.DiscountID
),
OrderSubtotals AS (
    SELECT 
        OrderID,
        OrderDate,
        SUM(DiscountedLineTotal) AS Subtotal
    FROM ItemDiscountCalc
    GROUP BY OrderID, OrderDate
),
CartDiscount AS (
    SELECT 
        OS.OrderID,
        OS.OrderDate,
        OS.Subtotal,
        CASE 
            WHEN D.DiscountLevel = 0 AND D.DiscountType = 0 THEN 
                OS.Subtotal * (1 - D.DiscountPercentage)

            WHEN D.DiscountLevel = 0 AND D.DiscountType = 1 THEN 
                OS.Subtotal - D.DiscountDollarAmount

            ELSE OS.Subtotal
        END AS AfterCartDiscount
    FROM OrderSubtotals OS
    LEFT JOIN Orders O ON OS.OrderID = O.OrderID
    LEFT JOIN Discounts D 
           ON O.DiscountID = D.DiscountID
)
SELECT 
    OrderID,
    OrderDate,
    ROUND(AfterCartDiscount * 1.0825, 2) AS TotalSale
FROM CartDiscount
ORDER BY OrderDate;
";

            return GetDataTable(sql,
                new SQLiteParameter("@StartDate", startDate.ToString("yyyy-MM-dd")),
                new SQLiteParameter("@EndDate", endDate.ToString("yyyy-MM-dd"))
            );
        }

        /// <summary>
        /// Retrieves inventory data based on a selected report type.
        /// </summary>
        /// <param name="reportType">
        /// The type of report:
        /// 0 = Active items only,
        /// 1 = Items below restock threshold,
        /// 2 = All items.
        /// </param>
        /// <returns>
        /// A DataTable containing inventory report data.
        /// </returns>
        public static DataTable GetInventoryReport(int reportType)
        {
            string sql = @"
        SELECT InventoryID, ItemName, Cost, RetailPrice, Quantity, RestockThreshold, Discontinued
        FROM Inventory
        WHERE 
            (@ReportType = 0 AND Discontinued = 0) OR
            (@ReportType = 1 AND Quantity < RestockThreshold) OR
            (@ReportType = 2)
        ORDER BY ItemName";

            return GetDataTable(sql,
                new SQLiteParameter("@ReportType", reportType)
            );
        }

        /// <summary>
        /// Retrieves a customer's full transaction history,
        /// including calculated totals with item-level and cart-level discounts and tax.
        /// </summary>
        /// <param name="personID">The PersonID of the customer.</param>
        /// <returns>
        /// A DataTable containing order history with totals.
        /// </returns>
        public static DataTable GetCustomerTransactionHistory(int personID)
        {
            string sql = @"
WITH ItemLines AS (
    SELECT 
        O.OrderID,
        O.OrderDate,
        OD.Quantity,
        I.RetailPrice,
        OD.InventoryID,
        OD.DiscountID AS ItemDiscountID
    FROM Orders O
    JOIN OrderDetails OD ON O.OrderID = OD.OrderID
    JOIN Inventory I ON OD.InventoryID = I.InventoryID
    WHERE O.PersonID = @PersonID
),
ItemDiscountCalc AS (
    SELECT 
        IL.OrderID,
        IL.OrderDate,
        CASE 
            WHEN D.DiscountLevel = 1 
                 AND D.InventoryID = IL.InventoryID
                 AND D.DiscountType = 0 THEN 
                     (IL.Quantity * IL.RetailPrice) * (1 - D.DiscountPercentage)

            WHEN D.DiscountLevel = 1
                 AND D.InventoryID = IL.InventoryID
                 AND D.DiscountType = 1 THEN 
                     (IL.Quantity * IL.RetailPrice) - D.DiscountDollarAmount

            ELSE (IL.Quantity * IL.RetailPrice)
        END AS DiscountedLineTotal
    FROM ItemLines IL
    LEFT JOIN Discounts D 
           ON IL.ItemDiscountID = D.DiscountID
),
OrderSubtotals AS (
    SELECT 
        OrderID,
        OrderDate,
        SUM(DiscountedLineTotal) AS Subtotal
    FROM ItemDiscountCalc
    GROUP BY OrderID, OrderDate
),
CartDiscount AS (
    SELECT 
        OS.OrderID,
        OS.OrderDate,
        OS.Subtotal,
        CASE 
            WHEN D.DiscountLevel = 0 AND D.DiscountType = 0 THEN 
                OS.Subtotal * (1 - D.DiscountPercentage)

            WHEN D.DiscountLevel = 0 AND D.DiscountType = 1 THEN 
                OS.Subtotal - D.DiscountDollarAmount

            ELSE OS.Subtotal
        END AS AfterCartDiscount
    FROM OrderSubtotals OS
    LEFT JOIN Orders O ON OS.OrderID = O.OrderID
    LEFT JOIN Discounts D 
           ON O.DiscountID = D.DiscountID
)
SELECT 
    FD.OrderID, 
    FD.OrderDate, 
    ROUND(FD.AfterCartDiscount * 1.0825, 2) AS Total,
    P.NameFirst || ' ' || P.NameLast AS CustomerName
FROM CartDiscount FD
JOIN Person P 
    ON P.PersonID = (SELECT O.PersonID FROM Orders O WHERE O.OrderID = FD.OrderID)
ORDER BY FD.OrderDate DESC;
";

            return GetDataTable(sql, new SQLiteParameter("@PersonID", personID));
        }

        /// <summary>
        /// Retrieves summarized order data for a specific person,
        /// including subtotal, discount applied, tax, and total.
        /// </summary>
        /// <param name="personID">The PersonID of the user.</param>
        /// <returns>
        /// A DataTable containing order summaries.
        /// </returns>
        public static DataTable GetOrdersByPerson(int personID)
        {
            string sql = @"
WITH ItemLines AS (
    SELECT 
        O.OrderID,
        O.OrderDate,
        OD.Quantity,
        I.RetailPrice,
        OD.InventoryID,
        OD.DiscountID AS ItemDiscountID
    FROM Orders O
    JOIN OrderDetails OD ON O.OrderID = OD.OrderID
    JOIN Inventory I ON OD.InventoryID = I.InventoryID
    WHERE O.PersonID = @PersonID
),
ItemDiscountCalc AS (
    SELECT 
        IL.OrderID,
        IL.OrderDate,
        CASE 
            WHEN D.DiscountLevel = 1 
                 AND D.InventoryID = IL.InventoryID
                 AND D.DiscountType = 0 THEN 
                     (IL.Quantity * IL.RetailPrice) * (1 - D.DiscountPercentage)

            WHEN D.DiscountLevel = 1
                 AND D.InventoryID = IL.InventoryID
                 AND D.DiscountType = 1 THEN 
                     (IL.Quantity * IL.RetailPrice) - D.DiscountDollarAmount

            ELSE (IL.Quantity * IL.RetailPrice)
        END AS DiscountedLineTotal
    FROM ItemLines IL
    LEFT JOIN Discounts D 
           ON IL.ItemDiscountID = D.DiscountID
),
OrderSubtotals AS (
    SELECT 
        OrderID,
        OrderDate,
        SUM(DiscountedLineTotal) AS Subtotal
    FROM ItemDiscountCalc
    GROUP BY OrderID, OrderDate
),
CartDiscount AS (
    SELECT 
        OS.OrderID,
        OS.OrderDate,
        OS.Subtotal,
        CASE 
            WHEN D.DiscountLevel = 0 AND D.DiscountType = 0 THEN 
                OS.Subtotal * (1 - D.DiscountPercentage)

            WHEN D.DiscountLevel = 0 AND D.DiscountType = 1 THEN 
                OS.Subtotal - D.DiscountDollarAmount

            ELSE OS.Subtotal
        END AS AfterCartDiscount,
        IFNULL(D.DiscountCode, 'No Discount') AS DiscountCode
    FROM OrderSubtotals OS
    LEFT JOIN Orders O ON OS.OrderID = O.OrderID
    LEFT JOIN Discounts D 
           ON O.DiscountID = D.DiscountID
)
SELECT 
    FD.OrderID, 
    FD.OrderDate, 
    FD.Subtotal,
    FD.DiscountCode,
    ROUND(FD.AfterCartDiscount * 0.0825, 2) AS Tax,
    ROUND(FD.AfterCartDiscount + FD.AfterCartDiscount * 0.0825, 2) AS Total
FROM CartDiscount FD
ORDER BY FD.OrderDate DESC;
";

            return GetDataTable(sql, new SQLiteParameter("@PersonID", personID));
        }

        /// <summary>
        /// Retrieves detailed line items for a specific order,
        /// including calculated line totals after discounts.
        /// </summary>
        /// <param name="orderID">The OrderID.</param>
        /// <returns>
        /// A DataTable containing item-level order details.
        /// </returns>
        public static DataTable GetOrderDetailsByOrderID(int orderID)
        {
            string sql = @"
SELECT 
    I.ItemName,
    OD.Quantity,
    I.RetailPrice,
    ROUND(
        OD.Quantity * I.RetailPrice
        - CASE WHEN D.DiscountType = 0 THEN IFNULL(OD.Quantity * I.RetailPrice * D.DiscountPercentage, 0) ELSE 0 END
        - CASE WHEN D.DiscountType = 1 THEN IFNULL(D.DiscountDollarAmount, 0) ELSE 0 END,
        2
    ) AS LineTotal
FROM OrderDetails OD
JOIN Inventory I ON OD.InventoryID = I.InventoryID
LEFT JOIN Discounts D ON OD.DiscountID = D.DiscountID
WHERE OD.OrderID = @OrderID;";

            return GetDataTable(sql,
                new SQLiteParameter("@OrderID", orderID));
        }

        /// <summary>
        /// Processes a complete order by inserting the order record,
        /// adding order details, and updating inventory quantities.
        /// All operations are executed within a transaction to ensure data integrity.
        /// </summary>
        /// <param name="order">The order object containing header information.</param>
        /// <param name="details">A list of order detail items.</param>
        /// <returns>
        /// The newly created OrderID.
        /// </returns>
        /// <exception cref="Exception">
        /// Throws an exception if the transaction fails.
        /// </exception>
        public static int ProcessOrder(Order order, List<OrderDetail> details)
        {
            using (SQLiteConnection conn = new SQLiteConnection(CONNECT_STRING))
            {
                conn.Open();

                using (SQLiteTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert the main order record and retrieve the new OrderID
                        string orderSql = @"
                        INSERT INTO Orders
                        (DiscountID, PersonID, EmployeeID, OrderDate, CC_Number, ExpDate, CCV)
                        VALUES (@DiscountID, @PersonID, @EmployeeID, @OrderDate, @CC_Number, @ExpDate, @CCV);
                        SELECT last_insert_rowid();";

                        int orderID;

                        using (SQLiteCommand orderCmd = new SQLiteCommand(orderSql, conn, trans))
                        {
                            orderCmd.Parameters.AddWithValue("@DiscountID",
                                order.DiscountID ?? (object)DBNull.Value);

                            orderCmd.Parameters.AddWithValue("@PersonID", order.PersonID);

                            orderCmd.Parameters.AddWithValue("@EmployeeID",
                                order.ManagerID > 0 ? (object)order.ManagerID : DBNull.Value);

                            orderCmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                            orderCmd.Parameters.AddWithValue("@CC_Number", order.CC_Number);
                            orderCmd.Parameters.AddWithValue("@ExpDate", order.ExpDate);
                            orderCmd.Parameters.AddWithValue("@CCV", order.CCV);

                            orderID = Convert.ToInt32(orderCmd.ExecuteScalar());
                        }

                        // Prepare reusable SQL commands for order details and inventory updates
                        string insertDetailSql = @"
                        INSERT INTO OrderDetails
                        (OrderID, InventoryID, DiscountID, Quantity)
                        VALUES (@OrderID, @InventoryID, @DiscountID, @Quantity);";

                        string updateInventorySql = @"
                        UPDATE Inventory
                        SET Quantity = Quantity - @Qty
                        WHERE InventoryID = @InventoryID;";

                        using (SQLiteCommand insertDetailCmd = new SQLiteCommand(insertDetailSql, conn, trans))
                        using (SQLiteCommand updateInventoryCmd = new SQLiteCommand(updateInventorySql, conn, trans))
                        {
                            // Define parameters once to avoid recreating them in each loop iteration
                            insertDetailCmd.Parameters.Add("@OrderID", DbType.Int32);
                            insertDetailCmd.Parameters.Add("@InventoryID", DbType.Int32);
                            insertDetailCmd.Parameters.Add("@DiscountID", DbType.Int32);
                            insertDetailCmd.Parameters.Add("@Quantity", DbType.Int32);

                            updateInventoryCmd.Parameters.Add("@Qty", DbType.Int32);
                            updateInventoryCmd.Parameters.Add("@InventoryID", DbType.Int32);

                            // Loop through each order detail and reuse the prepared commands
                            foreach (var detail in details)
                            {
                                insertDetailCmd.Parameters["@OrderID"].Value = orderID;
                                insertDetailCmd.Parameters["@InventoryID"].Value = detail.InventoryID;
                                insertDetailCmd.Parameters["@DiscountID"].Value =
                                    detail.DiscountID ?? (object)DBNull.Value;
                                insertDetailCmd.Parameters["@Quantity"].Value = detail.Quantity;

                                insertDetailCmd.ExecuteNonQuery();

                                updateInventoryCmd.Parameters["@Qty"].Value = detail.Quantity;
                                updateInventoryCmd.Parameters["@InventoryID"].Value = detail.InventoryID;

                                updateInventoryCmd.ExecuteNonQuery();
                            }
                        }

                        // Commit transaction if everything succeeds
                        trans.Commit();
                        return orderID;
                    }
                    catch
                    {
                        // Roll back transaction if anything fails
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Ensures that important database indexes exist to improve query performance.
        /// Creates indexes if they do not already exist.
        /// </summary>
        public static void EnsureIndexes()
        {
            using (SQLiteConnection conn = new SQLiteConnection(CONNECT_STRING))
            {
                conn.Open();

                string sql = @"
                CREATE INDEX IF NOT EXISTS idx_inventory_category ON Inventory(CategoryID);
                CREATE INDEX IF NOT EXISTS idx_inventory_name ON Inventory(ItemName);
                CREATE INDEX IF NOT EXISTS idx_orders_person ON Orders(PersonID);
                CREATE INDEX IF NOT EXISTS idx_orderdetails_order ON OrderDetails(OrderID);
                CREATE INDEX IF NOT EXISTS idx_orderdetails_inventory ON OrderDetails(InventoryID);
                CREATE INDEX IF NOT EXISTS idx_discounts_inventory ON Discounts(InventoryID);";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
