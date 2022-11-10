git config --global --unset http.proxy
git config --global --unset https.proxy
git config http.sslVerify "false"
git pull origin main
git add .
git commit -m "UI And Scene Controller"
git push origin main
git status
