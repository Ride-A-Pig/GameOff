git config --global --unset http.proxy
git config --global --unset https.proxy
git config http.sslVerify "false"
git pull origin main --allow-unrelated-histories
git status
