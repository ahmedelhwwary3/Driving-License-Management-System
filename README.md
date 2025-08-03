🚗🛂 Driving License Management System (DLMS)
A robust, enterprise-grade desktop application for managing the full lifecycle of driving licenses — from registration and testing to issuance, renewal, and auditing.
Built using C# (WinForms) and SQL Server with a clean 3-tier architecture, modular design, and real-world scalability.

🔧 Core Features
🎯 Functional Capabilities
Driver registration with validation and dynamic filtering

Full license lifecycle (issuance, renewal, replacement, violations)

Role-based access control using bitwise flags (Admin, Editor, Viewer)

File handling for driver photos and report exports

Outlook integration for email notifications

Export reports to Word/Excel via API

🔐 Security & Stability
SHA-256 password hashing

Soft-delete using status flags (no hard deletes)

Error logging via SQL triggers and centralized logging manager

Safe SQL using SqlParameter (null- and direction-safe)

Persistent local settings via Windows Registry

📈 Performance & Data Management
All DB operations handled through Stored Procedures

Efficient pagination using ROW_NUMBER() + OFFSET-FETCH

Reusable queries via MVTF (Multi-Value Table Functions)

Secure dynamic SQL using QUOTENAME()

🏗 Architecture & Design Patterns
3-Tier Architecture
UI Layer: WinForms + modular UserControls

Business Logic Layer: Extension methods, validation, serialization

Data Access Layer: ADO.NET + Stored Procedures

Dependency Injection
Constructor injection using delegates to decouple logic and enhance testability

SOLID Principles
SRP, ISP, DIP applied for scalable and maintainable code

🧠 Engineering Highlights
⚙ Transactions & Data Integrity
Atomic operations using BEGIN TRANSACTION

License auto-creation post driver registration

Embedded license history tracking at DB level

🧾 Logging System
Multi-layered logging:

SQL Logs via triggers (ErrorLogs table)

Windows Event Viewer logs (manifest-elevated)

Registry entries

Text file auditing

🎨 UI & Theming
Custom ThemeManager + IThemable interface

Supports three modes: Admin, Dark, Default

Recursive styling for all nested controls

➕ Role Permissions
Roles managed using bitwise flags

Efficient access checks (Add / Check / Remove)

🛠 Utilities & Helpers
HashSet<SqlParameter> to avoid duplicates

Delegates + Reflection for dynamic execution

Undo/Redo using serialized state snapshots

Custom extension methods for:

Type casting

Parameter binding

Result retrieval

🧪 Technologies Used
Category	Tools / Technologies
Language	C# (.NET Framework)
Database	SQL Server (SPs, Views, Triggers, MVTF, Session Context)
UI	WinForms
Architecture	3-Tier (UI, BLL, DAL)
Tools	Visual Studio 2022, Windows Registry, Outlook, Event Viewer
Libraries	ADO.NET, System.IO, Reflection, Serialization, Office Interop, etc.

🚀 How to Run
Open the solution in Visual Studio 2022

Attach the SQL Server database

Run the application

Use one of the following default accounts:

Role	Username	Password
Admin	User1	1111
Editor	User2	2222

