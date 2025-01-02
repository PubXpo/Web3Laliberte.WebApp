# Use compatilbe Node.js base image
FROM node:16 AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Use a lightweight web server
FROM nginx:alpine
COPY --from=build /app/build /usr/share/nginx/html

# Set up the environment and Nginx config for the correct environment
ARG ENVIRONMENT=dev
COPY nginx.$ENVIRONMENT.conf /etc/nginx/conf.d/default.conf

# Expose the port
EXPOSE 4010

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
