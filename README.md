<h1 align="center"><strong>Project for WPF Application for Task 2 PSNUS</strong></h1>
<h2 align="center">Create a WPF application that allows working with data for an arbitrary domain. Enable data viewing in a tabular format, as well as performing CRUD operations (Create, Read, Update, Delete) on tables from the database. Specification:</h2>

- Define a detailed data model (all necessary classes).

- Use Entity Framework to generate a database consisting of two tables in a 1-N (one-to-many) relationship.

- Implement the main window of the user interface that contains a tabular view of key data and buttons necessary for performing all CRUD operations.

- Implement a window containing a form for adding a new object to the appropriate database table (Create).

- Implement a window that displays all data about the selected object in an appropriate form (Read, i.e., Details).

- Use the window for adding a new object or create a new window containing a form for modifying an existing (selected) object (Update).

- When deleting an object, open a window that checks if the user is sure they want to perform this action (customize the built-in MessageBox dialog).

- Adequately bind all data (Data Binding), so that the data in the tabular view is refreshed in real-time.

- Implement all necessary validations and provide appropriate feedback in case of invalid input.

- Prevent the program from crashing when saving invalid data to the database (e.g., adding a primary key that already exists or a foreign key that does not exist).

- Style the appearance of the application. (Suggestion: use the Material Design library.)

