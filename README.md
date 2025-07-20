# 🚗🛂 Driving License Management System (DLMS)

A full-featured, maintainable desktop application for managing all driver license operations — from registration and testing to issuance, renewal, and auditing — built with a clean 3-tier architecture in **C# (WinForms)** and **SQL Server**.

---

## 🔧 Core Features

### 🎯 Functional Capabilities
- Driver registration with validation and dynamic data filtering.  
- Full license lifecycle: local & international issuance, renewal, replacement, violation handling.  
- Role-based access control (Admin, Editor, Viewer) using bitwise flags.  
- User activity logging (Create, Edit, Delete, Login) with timestamps.  
- File handling for storing driver images and exporting reports.

### 🔐 Security & Error Handling
- Hashed passwords using SHA-256.  
- Soft delete implementation (status flag instead of DELETE).  
- Error logging via triggers to `ErrorLogs` table (SP name, line, message, parameters).  
- Secure parameter handling with `SqlParameter` (handling nulls and direction).  
- Local storage of user credentials & UI themes via Windows Registry.

---

## 📈 Data Management & Performance

- Stored Procedures for all DB operations with output params & custom error handling.  
- Pagination for large datasets using `ROW_NUMBER()` and `OFFSET-FETCH`.  
- Efficient string normalization (e.g., `UPPER()` for usernames).  
- **MVTF** pattern (Multi-Value Table Function) for reusable queries.  
- `QUOTENAME()` usage to prevent SQL injection in dynamic SQL.

---

## 🛠 Architecture

- **UI Layer**: WinForms + modular `UserControls`.  
- **Business Logic Layer**: Extension methods, casting utilities, serialization, reflection.  
- **Data Access Layer**: `DBManager` + ADO.NET with stored procedures.
- **SOLID (SRP , ISP , DIP)
- **Database**: SQL Server with:
  - Triggers  
  - Views  
  - Stored Procedures  
  - Session Context (for tracking modified user)

---

## 🧠 Advanced Engineering Highlights

### ⚙ Transactions & Data Integrity
- Atomic multi-step operations using `BEGIN TRANSACTION`:
  - Automatically create driver when license is added.  
  - Update license status/history upon issuance.

### 🧾 Logging System
- Multi-layered logging:  
  - **Database Logs**  
  - **Windows Event Log**  
  - **Registry Entries**  
  - **Text Files**  
- Manifest used for permission elevation in Event Viewer.  
- Central `Logger` classes ensure unified logging behavior.

### 🔁 Undo/Redo & Reflection
- Redo/Undo functionality using serialized state snapshots.  
- Reflection used to inspect business-layer classes (only in DEBUG mode via `[Debug]` attribute).

### 🧩 Utility Libraries
- `HashSet<SqlParameter>` helpers for duplicate-free parameters.  
- Extension Methods for:
  - Type casting  
  - Scalar value retrieval  
  - Parameter binding  
- Utilities for image saving & operation log downloads.

### 🎨 UI Theming System
- `ThemeManager` class + `IThemable` interface.  
- 3 Modes:
  - Admin  
  - Dark  
  - Default  
- `SetTheme()` recursively applies styles across all controls and children.

### ➕ Bitwise Permission Logic
- Role permissions stored as byte flags.  
- Bitwise operations for:
  - Adding/updating permissions  
  - Verifying access  
  - Shifting values dynamically

---

## 🧪 Technologies Used

| Category     | Tools / Technologies                                  |
|--------------|--------------------------------------------------------|
| **Language** | C# (.NET Framework)                                    |
| **Database** | SQL Server (SPs, Views, Triggers, Context, Temp Tables)|
| **UI**       | WinForms                                               |
| **Architecture** | 3-Tier (UI, BLL, DAL)                            |
| **Tools**    | Visual Studio 2022, Windows Registry, Event Viewer     |
| **Libraries**| ADO.NET, System.IO, Serialization, Reflection, etc.    |

---

## 🚀 How to Run

1. Open the solution in **Visual Studio 2022**.  
2. Restore or attach the provided SQL Server database.  
3. Run the application.  
4. Log in using one of the default users:

| Role   | Username | Password |
|--------|----------|----------|
| Admin  | User1    | 1111     |
| Editor | User2    | 2222     |

---

## 📂 Project Repository

- **GitHub**
