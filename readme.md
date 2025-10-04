# Capital Gains CLI

This is a command-line application that calculates taxes for stock trade operations based on profit.
The application receives the operations in **JSON** format through `stdin`.
The outputs are also in **JSON** format through `stdout`.

---

## ⚙️ Requirements

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (or later) installed
* Runs on **Linux**, **macOS**, or **Windows**

---
<br/>

## 📂 Project Structure
```
Cg.Console/
 ├── Cg.Console/            # Main console application    
 ├── Cg.Console.Tests/      # Unit and integration tests
 ├── publish/               # Optional published executables (Linux/Mac/Win)
 └── README.md              # This file
```
---
<br/>

## 1️⃣ First Steps

1. Make sure you have the .NET 8 SDK (or later) installed.

2. Unzip the project into a local folder.

3. Open a terminal in the project root (where the .sln file is located).
---
<br/>

## ▶️ How to Run

### Option 1: Run from Source

```bash
dotnet run --project Cg.Console
```

The Input is a set of arrays containing stock market operations encoded in **JSON**

```json
[{"operation":"buy","unit-cost":10.00,"quantity":10000},{"operation":"sell","unit-cost":20.00,"quantity":5000}]
```

### Option 2: Run Published Executable

If you have the published binaries (optional):

* **Linux**

  ```bash
  ./publish/linux/Cg.Console
  ```
* **macOS**

  ```bash
  ./publish/osx/Cg.Console
  ```
* **Windows**

  ```powershell
  .\publish\windows\Cg.Console.exe
  ```
  ---
  <br/>

## ⚙️ How to Build the Project

In the terminal, set in the root of project run the build command:

```bash
dotnet build
```
---
<br/>

## 🧪 How to run the tests

In the terminal, set in the root of project run the following command:

```bash
dotnet test
```


> This runs both unit tests and integration tests.
Integration tests use the examples provided in the challenge specification.

## 📐 Design Decisions

### Models
* `TradeOperation` → input operation (buy/sell, unit cost, quantity).
* `TaxResult` → output result with the tax for each operation.
* `TradeSession` → tracks weighted average price, stock quantity and accumulated losses.

### Core Logic

  * `TradeService.` Receives the set of Inputs, applies the requested operations, manages the session variables (`TradeSession`) and returns the Tax Results
  * `Operations.` Implements the business rules that each operation entails.
    * `BaseOperation.` Abstract base class. Defines the basic properties and contracts that every current and future operation must define.
    * `BuyOperation.` Manages the Buy operations. Updates the Weighted average price and the current Stock of the session with each execution.
    * `SellOperation.` Manages the Sell operations. Updates the losses for the current set of operations and the Stock quantity.


### I/O Separation

* `Program.cs` only reads from `stdin` and writes to `stdout`.
* `Runner.cs` Receieves the Input Lines from the Program.cs. Each Input is a set of operations and must be managed in a different session.
---


## 🛠️ Technologies Used

* **C# 12 / .NET 8**
* **System.Text.Json** for JSON serialization/deserialization
* **MSTest** for testing

No external frameworks beyond the standard .NET libraries.

---
