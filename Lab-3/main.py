# -*- coding: utf-8 -*-
from grab import Grab
from bs4 import BeautifulSoup
import re
import json
import threading
from time import sleep
import urllib

g = Grab(
    user_agent = 'PR-Lab3 CoolBrowser V1.0.0',
    cookiefile = 'cookie.txt'
)


def download_image(pool, link, number):
    pool.acquire()

    print 'Descarcam imaginea numarul:', number
    print link

    urllib.urlretrieve(link, 'images/%d.jpg' % number)
    sleep(8)

    pool.release()


nickname = raw_input('Instagram Nickname: ')

# Îndeplinim un GET Request la pagina de isntagram.
work = g.go('https://www.instagram.com/%s' % nickname)

# Analizam raspunsul paginii.
if work.code == 404:
    print 'Eroare 404 - Utilizatorul nu exista!'
else:

    # Verificam erorile.
    if work.code != 200:
        print 'Greseala la nivel de server...'
        exit()

    print '-' * 40
    print 'Utlizatorul "%s" exista\n' % nickname

    soup = BeautifulSoup(work.body, "lxml")

    # Dobîndim JSON-ul cu content-ul utilizatorului.
    shared = re.compile('_sharedData = {(.+?)};')
    user_data = json.loads(
        '{%s}' % shared.findall(work.body)[0]
    )

    # Datele utlizatorului decodate în array.
    info = user_data['entry_data']['ProfilePage'][0]['user']

    # Statistica profilului utilziatorului.
    print 'ID:', info['id']
    print 'Numele:', info['full_name']
    print 'Urmareste:', info['follows']['count'], 'utilizatori'
    print 'Îl urmaresc:', info['followed_by']['count'], 'utilizatori'

    print '-' * 40
    print 'Raspunsul serverului:\n'
    print work.headers
    print '-' * 40

    # Informații despre content.
    media = info['media']
    print 'Numarul de fisiere:', media['count']

    total_images = 0

    # Avem nevoie doar de imagini.
    for node in media['nodes']:
        if node['is_video'] is False:
            total_images += 1

    print 'Descarcam primele:', total_images, 'imagini'

    # Numarul de thread-uri paralele
    descarcam_concomitent = int(total_images / 3)

    print 'Info: Concomitent se vor descarca %d imagini.\n\n' % descarcam_concomitent

    # Setarea semaforului.
    pool = threading.BoundedSemaphore(
        value = descarcam_concomitent
    )

    # Descarcam pozele.
    image_number = 1
    for node in media['nodes']:
        if node['is_video'] is False:

            download = threading.Thread(
                target=download_image, args=(
                    pool, node['display_src'], image_number
                )
            )

            download.start()

            image_number += 1