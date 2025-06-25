# UrlListApp-Express

UrlListApp-Express is a Node.js web application using Express and EJS, inspired by the original .NET Razor Pages version. It allows you to create, view, and manage lists of URLs.

## How It Works

- **Framework:** Built with Express and EJS for server-side rendering.
- **Static Files:** Served from the `public/` directory.
- **Dynamic Content:** Handled via EJS templates in the `views/` directory.
- **In-Memory Storage:** URL lists are stored in memory (no database required for demo).

## Usage

1. **Install dependencies:**
   ```bash
   npm install
   ```
2. **Run the App:**
   ```bash
   npm start
   ```
3. **Access the App:**
   - Open your browser and go to `http://localhost:3000`

## Project Structure

- `server.js` - Main Express server.
- `views/` - EJS templates for pages.
- `public/` - Static files (CSS, JS, images).

## Requirements
- Node.js 18 or later

## License
This project is part of the San Antonio GitHub Copilot Global Bootcamp 2025 and is intended for educational purposes.
