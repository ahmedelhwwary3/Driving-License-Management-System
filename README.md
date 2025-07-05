readme:

Driving License Management System 🚗🛂
A full-featured, maintainable desktop application for managing all driver license operations — from registration and testing to issuance, renewal, and auditing — built with a clean 3-tier architecture in C# (WinForms) and SQL Server.

🔧 Core Features
🎯 Functional Capabilities
Driver registration with validation and dynamic data filtering.
Full license lifecycle: local & international issuance, renewal, replacement, violation handling.
Role-based access control (Admin, Editor, Viewer) using bitwise flags.
User activity logging (Create, Edit, Delete, Login) with timestamps.
File handling for storing driver images and exporting reports.
🔐 Security & Error Handling
Hashed passwords with SHA-256.
Soft delete implementation (status flag instead of DELETE).
Error logging via Triggers to ErrorLogs table (SP name, line, message, parameters).
Secure parameter handling using SqlParameter with null & direction checks.
Registry-based local storage for user credentials & UI themes.
📈 Data Management & Performance
Stored procedures for all database operations with Output Parameters and Custom Errors.
Pagination for large datasets using ROW_NUMBER() and OFFSET-FETCH.
Efficient string normalization (e.g., UPPER() for consistent usernames).
Use of MVTF pattern for reusable procedures.
QUOTENAME() to prevent SQL injection in dynamic SQL queries.
🛠 Architecture
UI Layer: C# WinForms with modular UserControls.
Business Logic Layer: Extension methods, casting utilities, serialization.
Data Access Layer: DBManager + ADO.NET with stored procedures & error handling.
Database: SQL Server with:
Triggers
Views
Stored Procedures
Session Context (for tracking modified user)
🧠 Advanced Engineering Highlights
⚙ Transactions & Data Integrity
Atomic multi-step operations with BEGIN TRANSACTION for:
Creating drivers automatically when license files are added.
Updating license status and history after creation.
🧾 Logging System
Multi-layered logging (DB, EventLog, Registry, and File-based).
Windows Event Viewer integration with manifest to request elevation if needed.
Central Logger classes for unified logging experience.
🔁 Undo/Redo & Reflection
Redo/Undo functionality with state snapshots using serialization.
Reflection-based property inspection of business-layer classes (shown only in DEBUG mode via [Debug] attribute).
🧩 Utility Libraries
HashSet<SqlParameter> helper methods for duplicate-free parameter sets.
Custom Extension Methods for type casting, scalar retrieval, and parameter binding.
Image processing and log download utilities.
🎨 UI Theming System
Theme Manager class + IThemable interface.
3 Modes: Admin, Dark, Default.
SetTheme() applied recursively across controls for consistent appearance.
➕ Bitwise Permission Logic
Role permissions stored as byte flags.
Bitwise operations to add/verify permissions.
Bitwise shifts used to dynamically update Admin capabilities.
🧪 Technologies Used
Category	Tools/Technologies
Language	C# (.NET Framework)
Database	SQL Server (SPs, Views, Triggers, Context, Temp Tables)
UI Framework	WinForms
Architecture	3-Tier (UI, BLL, DAL)
Tools	Visual Studio 2022, Windows Registry, Event Viewer
Libraries	ADO.NET, System.IO, Serialization, Reflection, etc.
🚀 How to Run
Open the solution in Visual Studio 2022.
Restore/attach the provided SQL Server database.
Set up default users from the seed data:
Run the project and log in to explore the full functionality.
📂 Project Repository
📌 GitHub: Driving License Management System
👤 Author: Ahmed Elhwwary
📢 Telegram (Projects Showcase): @ahmedelhwwary3 🔗 LinkedIn: Ahmed Elhwwary

📬 Contact
For collaboration or freelance opportunities, feel free to reach out via GitHub or Telegram.
