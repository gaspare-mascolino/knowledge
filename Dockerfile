FROM python:alpine AS base
RUN pip install mkdocs
RUN pip install mkdocs-mermaid2-plugin
COPY /pages/documents/mkdocs-material /tmp/mkdocs/mkdocs-material
COPY pages /tmp/mkdocs/pages
COPY mkdocs.yml /tmp/mkdocs/
WORKDIR /tmp/mkdocs
RUN mkdocs build

