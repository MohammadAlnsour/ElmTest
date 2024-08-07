const PROXY_CONFIG = [
  {
    context: ["/api"],
    target: "https://localhost:7155",
    secure: false,
    logLevel: "error",
    changeOrigin: true,
  }
];
module.exports = PROXY_CONFIG;
