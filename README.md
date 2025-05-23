# 🎧 The Wild Cube – Audio Reactive Visualizer

**The Wild Cube** is an audio-reactive music visualizer built in Unity as part of the Junior Programmer pathway. The challenge started with a single cube — and evolved into a pseudo-toroidal sound sculpture.

### 🌟 What it does

- Generates a circular array of cubes arranged in a torus-like structure.
- Each cube reacts to a distinct frequency band of the audio spectrum.
- Real-time scaling and color emission are driven by harmonic amplitude using FFT data.
- Rainbow emission colors are mapped across bands for a vibrant pulse effect.
- Includes a custom camera orbit and a clean start button logic.

> 🎶 The soundtrack includes epic themes like *The Witcher*, enhancing the emotional impact of the scene.

---

### 🧠 How it works

- `MusicVisualizerManager.cs` distributes cubes in a circle and feeds them FFT data via `GetSpectrumData`.
- `AudioReactiveCube.cs` handles individual cube behavior: scaling + emissive color based on band amplitude.
- `CameraOrbit.cs` creates a smooth automatic orbit around the center.
- `MusicStarter.cs` handles delayed initialization for audio load (especially for WebGL).

---

### 🛠️ Technologies Used

- Unity Engine (2022.x)
- C# scripting
- FFT and audio spectrum analysis
- Dynamic emission lighting

---

### 💡 Purpose

This project is not a game — it's a **technical and artistic experiment**, meant to explore:
- Real-time audio visualization
- Procedural scene generation
- Unity audio workflows

It's included in my portfolio to demonstrate creative coding, technical polish, and a touch of audiovisual storytelling.

> ⚠️ Heavy Unity-generated folders like `/Library`, `/Logs`, `/Temp`, etc. are excluded via `.gitignore` for clean version control.
