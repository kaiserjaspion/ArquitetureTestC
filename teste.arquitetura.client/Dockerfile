FROM node:latest

WORKDIR "/app"
COPY package*.json ./
COPY vite*.ts ./
RUN npm install
COPY . .
RUN npm run build-only
EXPOSE 8082
EXPOSE 8083
#CMD ["sh", "-c", "http-server", "dist"] 
CMD ["sh","-c","npm run build"]



