# BTMContractDrafterApp

BTMContractDrafterApp is a .NET desktop tool for helping draft contract terms for player units, including mercenary units and clan-based units, on the BattleTech Mercenaries site.

> Note: This project is currently being reexamined for potential refactoring for the new rules.  It likely needs better clarity on how settings and defaults are loaded.
## Solution structure

This solution is divided into a shared library, a WPF desktop application, and test projects.

### BTMContractDrafter.Library
Shared core code used by the rest of the solution.

Responsibilities:
- data models
- serialization helpers
- save/load logic
- reusable utility code

### BTMContractDrafter.WPF
The desktop user interface project.

Responsibilities:
- application startup
- WPF windows and views
- view models
- UI-specific services
- UI data sources

### BtmContractDrafter.Library.XUnit
Automated tests for the shared library project.

Responsibilities:
- model behavior
- helper logic
- serialization and persistence-related behavior

### BtmContractDrafter.Wpf.XUnit
Automated tests for WPF-related logic.

Responsibilities:
- view model behavior
- service wiring
- UI-adjacent logic that can be tested outside the visual layer

## Current focus

This repository is being cleaned up incrementally with an emphasis on:
- warnings
- nullability issues
- maintainability
- small safe improvements

## Notes

The project is being improved gradually, so some areas may still be in transition as shared logic and WPF-specific logic are refined.