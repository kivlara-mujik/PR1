# -*- coding: utf-8 -*-
import urllib2
import re

try:
    from bs4 import BeautifulSoup
except:
    print 'Lipsește biblioteca BeautifulSoup'
    print 'git clone git@github.com:getanewsletter/BeautifulSoup4.git BS'
    print 'python setup.py install'
    exit()

def explica_sensul(cuvint):
    response = urllib2.urlopen('http://www.dex.ro/%s' % cuvint)
    data = response.read()

    soup = BeautifulSoup(data, "lxml")

    for meta in soup.findAll('div', {'class': 'res'}):
        print re.sub('<[^<]+?>', '', meta.text)
        print '-' * 60
