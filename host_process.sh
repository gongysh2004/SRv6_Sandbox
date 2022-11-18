#!/usr/bin/env bash


### to make sure /mydata is large enough, for example 500G


set -e -u -o pipefail


# Functions
function run_stage {
    echo "==> "$1": Starting"
    $1
    echo "==> "$1": Complete"
}
#  mkfs.btrfs -f  /dev/sdb
function bootstrap_vagrant() {

  if [ ! -x "/usr/bin/vagrant" ]
  then
    echo "Installing vagrant and associated tools..."
    #add-apt-repository ppa:jacob/virtualisation
    #apt-get update
    apt-get -y install btrfs-progs libvirt-daemon libvirt-daemon-system
    sudo apt-get -y install qemu-kvm  libvirt-dev nfs-kernel-server qemu-utils libvirt-dev ruby-dev
    sudo adduser $USER libvirtd

    VAGRANT_SHA256SUM="f70b244514c91f92ba3922e3490fd46ce340295fb70b7fe938d6811dbaa9cf63"  # version 2.3.3
    curl -o /tmp/vagrant.deb https://releases.hashicorp.com/vagrant/2.3.3/vagrant_2.3.3-1_amd64.deb
    echo "$VAGRANT_SHA256SUM  /tmp/vagrant.deb" | sha256sum -c -
    sudo dpkg -i /tmp/vagrant.deb
  fi


  echo "Installing vagrant plugins if needed..."
  vagrant plugin list | grep -q vagrant-libvirt || vagrant plugin install vagrant-libvirt --plugin-version 0.10.0
  vagrant plugin install vagrant-mutate
  run_stage cloudlab_setup
}
function cloudlab_setup() {

  #echo "mkfs.btrfs /dev/sdb"
  mount /dev/sdb /var/lib/libvirt/images
}


run_stage bootstrap_vagrant
exit 0
