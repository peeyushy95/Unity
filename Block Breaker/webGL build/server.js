var express =  require('express');
var path =  require('path');

const app = express();

app.use('/Build', express.static('Build'));
app.use('/TemplateData', express.static('TemplateData'));

app.get('*', function (req, res) {
  res.sendFile(path.join(__dirname, "/index.html"));
});

app.listen(8080, function() {
  console.log('API Server listening on port 8080!');
});
