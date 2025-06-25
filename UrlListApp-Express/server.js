const express = require('express');
const bodyParser = require('body-parser');
const path = require('path');

const app = express();
const PORT = process.env.PORT || 3000;

// In-memory data store
let urlLists = [];

app.set('view engine', 'ejs');
app.set('views', path.join(__dirname, 'views'));
app.use(bodyParser.urlencoded({ extended: false }));
app.use(express.static(path.join(__dirname, 'public')));

// Home - list all URL lists
app.get('/', (req, res) => {
  res.render('index', { urlLists });
});

// Show form to create a new list
app.get('/create', (req, res) => {
  res.render('create', { error: null });
});

// Handle new list creation
app.post('/create', (req, res) => {
  const { title, customUrl } = req.body;
  if (!title) {
    return res.render('create', { error: 'Title is required.' });
  }
  if (customUrl && urlLists.some(l => l.customUrl === customUrl)) {
    return res.render('create', { error: 'Custom URL is already taken.' });
  }
  const url = customUrl || `list${Date.now()}`;
  urlLists.push({ title, customUrl: url, createdAt: new Date(), urls: [] });
  res.redirect(`/view/${url}`);
});

// View a specific list
app.get('/view/:customUrl', (req, res) => {
  const list = urlLists.find(l => l.customUrl === req.params.customUrl);
  if (!list) return res.status(404).send('List not found');
  res.render('view', { list });
});

// Static files and error handling
app.use((req, res) => {
  res.status(404).send('Page not found');
});

app.listen(PORT, () => {
  console.log(`UrlListApp-Express running at http://localhost:${PORT}`);
});
