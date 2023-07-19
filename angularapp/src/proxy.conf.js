const PROXY_CONFIG = [
  {
    context: [
      "/api/",
    ],
    target: "http://localhost:5095",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
