## Dynamic Tile-Based Background System

This script implements an advanced, camera-relative background spawning system that dynamically loads and unloads tiles based on player movement, optimizing memory usage and rendering performance.

**Key Technical Features**:
- 📍 **Camera-Relative Coordinate Calculation**: Converts world space to tile coordinates for precise positioning
- 🧠 **Intelligent Memory Management**: Uses Dictionary<Vector2Int, GameObject> for O(1) tile access and instantiation/destruction
- 🎯 **Viewport Culling**: Dynamically calculates visible tiles based on camera orthographic size and aspect ratio
- ⚡ **Performance Optimization**: Implements efficient tile recycling to minimize Instantiate/Destroy calls

**Complexity Highlight**: Solves the classic "infinite runner" background problem with a scalable, performance-conscious approach suitable for large, open-world environments.
