
🚗🛂 Driving License Management System (DLMS)
A robust, enterprise-grade desktop application for managing the entire lifecycle of driving licenses — from registration and testing to issuance, renewal, and auditing. Built with clean 3-tier architecture in C# (WinForms) and SQL Server, with modular design and real-world scalability.

🔧 Core Features
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
🎯 Functional Capabilities
• Driver registration with validation and dynamic filtering.
• Full license lifecycle (issuance, renewal, replacement, violations).
• Role-based access control via bitwise flags (Admin, Editor, Viewer).
• File handling for driver photos and report exports.
• Outlook integration for employee email notifications.
• Export reports (CRUD operations, users, etc.) via API to Word/Excel.

🔐 Security & Stability
• SHA-256 password hashing.
• Soft-delete logic (status flags instead of hard deletes).
• Error logging via triggers and centralized logging manager.
• Safe SQL handling using SqlParameter (null and direction-safe).
• Local storage (user settings, themes) via Windows Registry.

📈 Performance & Data Management
• All DB operations via Stored Procedures with output params & custom error flows.
• Efficient pagination (ROW_NUMBER() + OFFSET-FETCH).
• MVTF (Multi-Value Table Functions) for reusable queries.
• QUOTENAME() used for secure dynamic SQL generation.

🏗 Architecture & Patterns
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
🧱 3-Tier Architecture:
• UI Layer: WinForms + modular UserControls
• Business Logic Layer: Extension methods, serialization, validation
• Data Access Layer: ADO.NET + stored procedures

🧩 Dependency Injection:
• Custom delegates passed via constructor injection to decouple business logic and improve testability.

🧪 SOLID Principles:
• SRP, ISP, DIP applied across layers for maintainability.

🧠 Engineering Highlights
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
⚙ Transactions & Data Integrity:
• Atomic operations using BEGIN TRANSACTION (e.g., license auto-creation after driver registration).
• License history and status tracking embedded in DB logic.

🧾 Logging System:
• Multi-layered logging:
  - SQL Logs (ErrorLogs table via triggers)
  - Windows Event Viewer (via manifest-elevated logging)
  - Registry entries
  - Text files for auditing

🎨 UI & Theming:
• Custom ThemeManager + IThemable interface
• Three modes: Admin, Dark, Default
• Recursive styling applied across all nested controls

➕ Role Permissions:
• Roles managed via bitwise flags
• Fast checks using bitwise operations (Add, Check, Remove)

🛠 Utilities & Helpers:
• HashSet<SqlParameter> to prevent duplicates
• Delegates + reflection for flexible execution
• Undo/Redo state management using serialized snapshots
• Custom extension methods (type casting, param binding, result retrieval)

🧪 Technologies Used
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
Category        | Tools / Technologies
----------------|----------------------
Language        | C# (.NET Framework)
Database        | SQL Server (SPs, Views, Triggers, MVTF, Session Context)
UI              | WinForms
Architecture    | 3-Tier (UI, BLL, DAL)
Tools           | Visual Studio 2022, Windows Registry, Outlook, Event Viewer
Libraries       | ADO.NET, System.IO, Reflection, Serialization, Office Interop, etc.

🚀 How to Run
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
1. Open solution in Visual Studio 2022.
2. Attach the SQL Server database.
3. Run the application.
4. Use one of the default accounts:

Role    | Username | Password
--------|----------|---------
Admin   | User1    | 1111
Editor  | User2    | 2222
