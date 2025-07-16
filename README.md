# Unity State-Based Movement System 🚀

This is a lightweight and extendable movement system using the State Pattern.

## Features
- State machine with generic support (`StateMachine<T>`)
- Easily add new movement types (e.g., Walk, Run, Dash)
- Rigidbody-based physics movement
- Inspector-configurable states

## How to Use
1. Attach `Movement`, `PlayerInput`, and `Rigidbody` to your player.
2. Define your `MovementStates` in the Inspector.
3. Switch states using key input or logic.

## Example
Press `Left Shift` to run, release to walk again.

---

> Created for learning and reuse in Unity projects.
# StateMachine
