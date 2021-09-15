FROM python:alpine AS base
RUN pip install mkdocs
COPY mkdocs-material /tmp/mkdocs/mkdocs-material
COPY pages /tmp/mkdocs/pages
COPY mkdocs.yml /tmp/mkdocs/
WORKDIR /tmp/mkdocs
RUN mkdocs build

