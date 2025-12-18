# OldPhonePad - C# Coding Challenge

A C# solution for the OldPhonePad coding challenge, simulating the text input method used on old mobile phones with multi-tap keypads.

## Problem Description

Old mobile phones required pressing a number key multiple times to cycle through letters assigned to that key. For example:
- Press `2` once for 'A', twice for 'B', three times for 'C'
- Press `7` once for 'P', twice for 'Q', three times for 'R', four times for 'S'

### Special Keys
- `*` - Backspace (delete the last character)
- `#` - Send/End input
- ` ` (space) - Pause to separate consecutive presses of the same key

## Keypad Mapping

```
1 -> &'(
2 -> ABC
3 -> DEF
4 -> GHI
5 -> JKL
6 -> MNO
7 -> PQRS
8 -> TUV
9 -> WXYZ
0 -> (space)
```

## Examples

| Input | Output | Explanation |
|-------|--------|-------------|
| `33#` | E | Press 3 twice → E |
| `227*#` | B | 22→B, 7→P, *→delete P, result: B |
| `4433555 555666#` | HELLO | 44→H, 33→E, 555→L, (space)555→L, 666→O |
| `8 88777444666*664#` | TURING | 8→T, 88→U, 777→R, 444→I, 666→N, *→delete, 66→N, 4→G |

## Project Structure

```
PhonePadApp/
├── PhoneKeypad.cs          # Main logic implementation
├── Program.cs              # Console runner with example test cases
├── PhonePadApp.csproj      # Project file
├── PhonePadApp.Tests/      # Unit tests
│   ├── OldPhonePadTests.cs
│   └── PhonePadApp.Tests.csproj
├── README.md               # This file
└── AI_USAGE.md             # AI tools usage documentation
```

## How to Run

### Prerequisites
- .NET 10.0 SDK (or adjust TargetFramework in .csproj files)

### Run the Console Application
```bash
dotnet run
```

### Run Unit Tests
```bash
dotnet test PhonePadApp.Tests/PhonePadApp.Tests.csproj
```

## Algorithm Complexity

- **Time Complexity**: O(n) where n is the length of the input string
- **Space Complexity**: O(n) for the output StringBuilder (worst case: all characters produce output)

## Implementation Details

The algorithm uses a single-pass approach:
1. Track the current button being pressed and the press count
2. When a different button is pressed (or a special key), "commit" the current character
3. Handle special cases:
   - `#` terminates input processing
   - `*` removes the last character from output
   - ` ` (space) acts as a separator to allow consecutive presses of the same key

## License

This project is created as part of a coding challenge.
