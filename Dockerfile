FROM gasparemascolino/knowledge as builder
RUN pip install markdown-include==0.6.0
COPY mkdocs-material /tmp/mkdocs/mkdocs-material
COPY pages /tmp/mkdocs/pages
COPY mkdocs.yml /tmp/mkdocs/
WORKDIR /tmp/mkdocs
# hadolint ignore=SC2035 
RUN ls -l && mkdocs build && ls -l * 
    #&& cp -r /tmp/mkdocs/site/* /usr/share/nginx/html/
    #&& rm -rf /tmp/mkdocs
FROM gasparemascolino/knowledge
COPY --from=builder /tmp/mkdocs/site /usr/share/nginx/html/
RUN chmod g+rwx /var/cache/nginx /var/run /var/log/nginx /usr/share/nginx/html
COPY nginx/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 9080
USER 1000080000
