"use strict";
const bodyParser = require("body-parser");
const busboyBodyParser = require("busboy-body-parser");
const morgan = require("morgan");
const consolidate = require("consolidate");
const express = require("express");
const app = express();
const apiRouter = require("./Routes/ApiRouter");
const mstRouter = require("./Routes/MstRouter");
const mustache_ex = require("mustache-express");
const path = require("path");

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(busboyBodyParser());

app.use("/api", apiRouter);
app.use("", mstRouter);
app.use(express.static("./public"));
app.use(express.static("./Data"));
app.use(morgan("dev"));

const expressSwaggerGenerator = require("express-swagger-generator");
const expressSwagger = expressSwaggerGenerator(app);

const options = {
	swaggerDefinition: {
		info: {
			description: "description",
			title: "title",
			version: "1.0.0",
		},
		host: "localhost:3000",
		produces: ["application/json"],
	},
	basedir: __dirname,
	files: ["./routes/**/*.js", "./models/**/*.js"],
};
expressSwagger(options);

const viewsDir = path.join(__dirname, "views");
app.engine("mst", mustache_ex(path.join(viewsDir, "partials")));
app.set("views", viewsDir);
app.set("view engine", "mst");

app.listen(3000, () => {});
