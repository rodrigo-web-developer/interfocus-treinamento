var express = require("express");
var app = express();
app.use(express.static('.'));

app.get(/.+\.(js|ico|html|png|css|map)$/, function(req, res) {
    res.sendFile(req.originalUrl.replace(/^./, ""));
});
app.get(/.+$/, function(req, res) {
    res.sendFile(__dirname + "/index.html");
});

app.listen(3000);

